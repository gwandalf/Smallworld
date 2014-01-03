using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Modele.Jeu;
using Modele.Creation;
using SmallWorldLib.GeneratedCode;
using SmallWorldLib.GeneratedCode.Vue;
using Wrapper;
using System.ComponentModel;
using Modele.Jeu.Joueur;
using System.Windows.Controls.Primitives;
namespace WPF
{
    public enum Tile : int
    {
        DESERT = 1,
        FOREST,
        LOWLAND,
        MOUTAIN,
        SEA,
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Map : Window
    {
        CarteI map;/*
        MonteurPartie mp;
        ImageFactory imageBrushFactory = new ImageFactory();*/
        PartieI partie;
        Rectangle selectedVisual;
        //StackPanel _selectedUnit;
        
        public Map(PartieI p, string nameP1, string nameP2)
        {
            InitializeComponent();
            partie = p;

            //partie.start();
           
           // configurer l'affichage selon les noms de joueurs
        }

        private FabriqueI createFabrique(Nation nation)
        {
            switch (nation)
            {
                case Nation.GAUL:
                    return new Fabrique<Gaulois>();
                case Nation.NAIN:
                    return new Fabrique<Nain>();
                case Nation.VIKING:
                    return new Fabrique<Viking>();
                default:
                    return null;
            }
        }
        private Partie config(List<FabriqueI> fu, MonteurPartie mp)
        {
            GameInitiator.INSTANCE.FabriquesUnite = fu;
            GameInitiator.INSTANCE.MonteurPartie = mp;

            //Creation
            return (Partie)GameInitiator.INSTANCE.creerPartie();
        }
        
        /// <summary
        ///  Click on end of turn button
        /// </summary>
        
        private void EndOfTurnButton_Click(object sender, RoutedEventArgs e)
        {
                //le joueur a terminé son tour, faire tous les changements nécessaires
        }

        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            //le bouton gauche a été pressé
            //détecter l'endroit et faire quelque chose
            InfoLabel.Content = "Aucune unité";
            if(selectedVisual != null)
                InfoLabel.Content = "unité présente";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            map = partie.Carte;

            for (int c = 0; c < map.Dim; c++)
            {
                mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50, GridUnitType.Pixel) });
            }

            for (int l = 0; l < map.Dim; l++)
            {
                mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(50, GridUnitType.Pixel) });
                for (int c = 0; c < map.Dim; c++)
                {
                    AffichableI tile = map.makeView(l, c);
                    var rect = createRectangle(l, c, tile);
                    mapGrid.Children.Add(rect);
                }
            }

            
            //1. En fait il faut pour chaque joueur, positionner une image en fonction de son peuple: FONCTIONNE
            
            //2. TODO: Comme les unités sont déjà positionnées dans le modèle, il faut il faut associer le clic d'un rectangle 
            //   avec la recherche des unités présentes à cette position, pour afficher une petite fenêtre récapitulative
            
            foreach (Joueur i in partie.Joueurs)
            {   
                VueUniteI view = i.Unites[0].makeView();
                Tuple<int, int> t;
                map.PositUnite.TryGetValue(i.Unites[0], out t);
                var rect = createRectangle(t.Item1, t.Item2, view);
                view.Rectangle = rect;
                view.PropertyChanged += new PropertyChangedEventHandler(redraw);
                mapGrid.Children.Add(rect);
            }
            /*
            foreach (UniteI u in map.PositUnite.Keys)
            {
                //Donc s'il y a plusieurs unités sur la case, on refait à chaque fois un nouveau rectangle
                VueUniteI view = u.makeView();
                Tuple<int, int> t;
                map.PositUnite.TryGetValue(u, out t);
                var rect = createRectangle(t.Item1, t.Item2, view);
                view.Rectangle = rect;
                view.PropertyChanged += new PropertyChangedEventHandler(redraw);
                mapGrid.Children.Add(rect);
            }
            */
            //updateUnitUI();
           
        }

        public void redraw(object sender, PropertyChangedEventArgs e)
        {
            var tile = sender as VueUniteI;
            UniteI u = tile.Unite;
            Tuple<int, int> t;
            map.PositUnite.TryGetValue(u, out t);
            mapGrid.Children.Remove(tile.Rectangle);
            var rect = createRectangle(t.Item1, t.Item2, tile);
            tile.Rectangle = rect;
            mapGrid.Children.Add(rect);
        }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <param name="l"></param>
            /// <param name="tile"></param>
            /// <returns></returns>
            private Rectangle createRectangle(int c, int l, AffichableI tile)
            {
                var rectangle = new Rectangle();
                rectangle.Fill = tile.Image;

                if (tile.Image == null)
                {
                    MessageBox.Show(this,
                    "image null",
                    "debug",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

                Grid.SetColumn(rectangle, c);
                Grid.SetRow(rectangle, l);
                rectangle.Tag = tile;
                rectangle.Stroke = Brushes.Gray;
                rectangle.StrokeThickness = 1;

                rectangle.MouseLeftButtonDown += new MouseButtonEventHandler(rectangle_MouseLeftButtonDown);
                return rectangle;
            }

           
            /// <summary
            ///  Fait les maj d'affichages nécessaires
            /// </summary>
            private void updateUnitUI()
            {
              
            }

        /*
            protected void btnUpdateTestTBL_OnClick(object sender, RoutedEventArgs e)
            {
                this.popup1.IsOpen = true;
            }
        */
            protected void btnPopup_OnClick(object sender, RoutedEventArgs e)
            {
                //TODO completer
            }

            /// <summary>
            /// Called after each click on the map
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var unite = sender as UniteI;
                var rectangle = sender as Rectangle;
                var tile = rectangle.Tag as AffichableI;
                int row = Grid.GetRow(rectangle);
                int column = Grid.GetColumn(rectangle);

                if (selectedVisual != null)
                {
                    if (!map.isEmpty(Grid.GetRow(selectedVisual), Grid.GetColumn(selectedVisual)))
                        selectedVisual.StrokeThickness = 2;
                    else
                        selectedVisual.StrokeThickness = 1;
                }
                selectedVisual = rectangle;
                selectedVisual.Tag = tile;
                rectangle.StrokeThickness = 3;
                InfoLabel.Content = String.Format("[{0:00} - {1:00}] {2}", row, column, tile);

                //affiche le nb d'unités sur la case
                unitInfoPanel.Content = getListUnitInt(row, column);

                tile.mouseLeftButtonDown();
                updateInfo();

                //Affichage des unités présentes à l'endroit
                
                //ca ne rend rien de bien

                
                /*
                Popup codePopup = new Popup();
                TextBlock popupText = new TextBlock();
                popupText.Text = "Popup Text";
                popupText.Background = Brushes.LightBlue;
                popupText.Foreground = Brushes.Blue;
                codePopup.Child = popupText;
                panel.Children.Add(codePopup);
                //panel.Children.Add(getListUnit(row, column));
                 */
                e.Handled = true;
            }

            /// <summary>
            /// test ERREUR
            /// </summary>
            /// <param name="u"></param>
            /// <returns></returns>
            private int getListUnitInt(int row, int column)
            {
                int i =0;

                //pour chaque unité on regarde si elle est en position en paramètre
                /*
                foreach (UniteI u in map.PositUnite.Keys)
                {
                    //j'essaye d'avoir la position de chaque unité
                    VueUniteI view = u.makeView();
                    Tuple<int, int> t;
                    map.PositUnite.TryGetValue(u, out t);
                    if (t.Item1 == row && t.Item2 == column || t.Item1 == column && t.Item2 == row){
                        i++;
                    }
                }
                /*
                Label lbLife = new Label();
                lbLife.Content = "Vie : ";
                Label lbOff = new Label();
                lbOff.Content = "Attaque : ";
                Label lbDeff = new Label();
                lbDeff.Content = "Defense : ";

                stack.Children.Add(lbLife);
                stack.Children.Add(lbOff);
                stack.Children.Add(lbDeff);
                */

                return i;
            }

            /// <summary>
            /// Whenever a unit is selected a Stackpanel of informations is given
            /// </summary>
            /// <param name="u"></param>
            /// <returns></returns>
            private StackPanel getListUnit(int row, int column)
            {
                //creation de la stack   
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;

                //pour chaque unité on regarde si elle est en position en paramètre
                foreach (UniteI u in map.PositUnite.Keys)
                {
                    //j'essaye d'avoir la position de chaque unité
                    VueUniteI view = u.makeView();
                    Tuple<int, int> t;
                    map.PositUnite.TryGetValue(u, out t);
                    var rect = createRectangle(t.Item1, t.Item2, view);
                    view.Rectangle = rect;
                    view.PropertyChanged += new PropertyChangedEventHandler(redraw);
                    stack.Children.Add(rect);
                }
                /*
                Label lbLife = new Label();
                lbLife.Content = "Vie : ";
                Label lbOff = new Label();
                lbOff.Content = "Attaque : ";
                Label lbDeff = new Label();
                lbDeff.Content = "Defense : ";

                stack.Children.Add(lbLife);
                stack.Children.Add(lbOff);
                stack.Children.Add(lbDeff);
                */
                stack.Tag = row+column;

                return stack;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            private void perform_action(int row, int column)
            {
               
            }

            /// <summary>
            /// Called after each turn, allows to update informations displayed about the state of game
            /// </summary>
            private void updateInfo()
            {
                NbTurnsLeft.Content = "Tours restants : " + partie.NombreTours;
                Units1Label.Content = "Unitées restantes : " + partie.Joueurs[0].NbUnitesJouables;
                Units2Label.Content = "Unitées restantes : " + partie.Joueurs[1].NbUnitesJouables;
                Points1Label.Content = "Points : " + partie.Joueurs[0].Points;
                Points2Label.Content = "Points : " + partie.Joueurs[1].Points;
            }

            /// <summary>
            /// Whenever a unit is selected a Stackpanel of informations is given
            /// </summary>
            /// <param name="u"></param>
            /// <returns></returns>
            private StackPanel getUnitDescription(Unite u)
            {
                StackPanel stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                if (u.Deplacement > 1)
                    stack.Background = new SolidColorBrush(Colors.LightGray);
                else
                    stack.Background = new SolidColorBrush(Colors.DarkGray);

                Label lbLife = new Label();
                lbLife.Content = "Vie : " + u.Vie;
                Label lbOff = new Label();
                lbOff.Content = "Attaque : " + u.Attaque;
                Label lbDeff = new Label();
                lbDeff.Content = "Defense : " + u.Defense;

                stack.Children.Add(lbLife);
                stack.Children.Add(lbOff);
                stack.Children.Add(lbDeff);

                stack.Tag = u;

                return stack;
            }
    }
}
