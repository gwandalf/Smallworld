﻿using System;
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
using Implementation.Modele.Jeu;
using Implementation.Modele.Jeu.Unit;
using Interfaces.Modele.Jeu.Unit;
using Implementation.Modele.Creation;
using Interfaces.Modele.Jeu;
using Interfaces.Modele.Creation;
using Implementation.Vue;
using Interfaces.Vue;
using Wrapper;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
namespace WPF
{/*
    public enum Tile : int
    {
        DESERT = 1,
        FOREST,
        LOWLAND,
        MOUTAIN,
        SEA,
    }*/
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Map : Window
    {
        CarteI map;
        Partie partie;
        Rectangle selectedVisual;
        StackPanel _selectedUnit;
        VueCase[,] _suggestions;
        List<VueCase> buff_sug;

        public Map(PartieI p, string nameP1, string nameP2)
        {
            InitializeComponent();
            partie = (Partie)p;
            partie.PropertyChanged += new PropertyChangedEventHandler(partie_PropertyChanged);
            partie.Joueurs[0].Nom = nameP1;
            partie.Joueurs[1].Nom = nameP2;
            partie.Carte.PropertyChanged += new PropertyChangedEventHandler(carte_PropertyChanged);
            _suggestions = new VueCase[p.Carte.Dim, p.Carte.Dim];
            buff_sug = new List<VueCase>();
        }

        private void partie_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show(this,
                "La victoire revient à " + partie.Gagnant.Nom + " !",
                "Partie terminée",
                MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void carte_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Legion"))
            {
                LegionI i = partie.Carte.TmpLegion;
                VueLegionI view = i.makeView();
                var rect = createRectangle(i.Ligne, i.Colonne, view);
                view.Rectangle = rect;
                view.PropertyChanged += new PropertyChangedEventHandler(redraw);
                mapGrid.Children.Add(rect);
            }
            else
            {
                string[] pos = e.PropertyName.Split(';');
                Rectangle rectangle =  _suggestions[Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1])].Rectangle;
                rectangle.Stroke = Brushes.Green;
                rectangle.StrokeThickness = 5;
                buff_sug.Add(_suggestions[Convert.ToInt32(pos[0]), Convert.ToInt32(pos[1])]);
            }
        }
        
        private Partie config(List<FabriqueI> fu, MonteurPartie mp)
        {
            GameInitiator.INSTANCE.FabriquesUnite = fu;
            GameInitiator.INSTANCE.MonteurPartie = mp;

            //Creation
            return (Partie)GameInitiator.INSTANCE.creerPartie();
        }

        /// <summary>
        ///  Click on end of turn button
        /// </summary>
        private void EndOfTurnButton_Click(object sender, RoutedEventArgs e)
        {
            partie.finTour();
            updateInfo();
        }

        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            //le bouton gauche a été pressé
            InfoLabel.Content = "Aucune unité";
            if (selectedVisual != null)
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
                    tile.Rectangle = rect;
                    _suggestions[l,c] = (VueCase)tile;
                    mapGrid.Children.Add(rect);
                }
            }

            foreach (LegionI i in map.Legions)
            {
                VueLegionI view = i.makeView();
                var rect = createRectangle(i.Ligne, i.Colonne, view);
                view.Rectangle = rect;
                view.PropertyChanged += new PropertyChangedEventHandler(redraw);
                mapGrid.Children.Add(rect);
            }
        }

        public void redraw(object sender, PropertyChangedEventArgs e)
        {
            var tile = sender as VueLegionI;
            LegionI l = tile.Legion;
            if (e.PropertyName.Equals("DetruireLegion"))
                mapGrid.Children.Remove(tile.Rectangle);
            else
                updateUnitInfo(l);
        }
        /**
         * Gives a specific children 
         */
        private Rectangle GetChildren(Grid grid, int row, int column)
        {
            foreach (Rectangle child in grid.Children)
            {
                if (Grid.GetRow(child) == row
                      &&
                   Grid.GetColumn(child) == column)
                {
                    return child;
                }
            }
            return null;
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

        /// <summary>
        /// Called after each click on the map : click on an item (unit or case) and do delegates the action to it
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

            for (int i = 0 ; i < buff_sug.Count; i++)
            {
                if (!map.isEmpty(Grid.GetRow(buff_sug[i].Rectangle), Grid.GetColumn(buff_sug[i].Rectangle)))
                    buff_sug[i].Rectangle.StrokeThickness = 2;
                else
                    buff_sug[i].Rectangle.StrokeThickness = 1;
                buff_sug[i].Rectangle.Stroke = Brushes.Gray;
            }
            buff_sug = new List<VueCase>();

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

            //affiche les unités sur la case
            updateUnitInfo(null);
            tile.mouseLeftButtonDown();
            updateInfo();
            e.Handled = true;
        }

        /// <summary>
        /// Called after each turn, allows to update informations displayed about the state of game
        /// </summary>
        private void updateInfo()
        {
            Nation1Label.Content = partie.Joueurs[0].Nom;
            Nation2Label.Content = partie.Joueurs[1].Nom;
            NbTurnsLeft.Content = "Tours restants : " + partie.NombreTours;
            Units1Label.Content = "Tour : " + partie.Joueurs[0].Turn;
            Units2Label.Content = "Tour : " + partie.Joueurs[1].Turn;
            Points1Label.Content = "Points : " + partie.Joueurs[0].Points;
            Points2Label.Content = "Points : " + partie.Joueurs[1].Points;

        }
        /*
        * Update information displayed about unit in the tile with line and column
        */
        private void updateUnitInfo(LegionI legion)
        {
            //effacer le contenu precedent
            unitInfoPanel.Children.Clear();
            if (legion != null)
            {
                //avec la position on trouve a qui appartient les unites (utile pour permettre de jouer
                //on recupère la liste des unites présentes à cet endroit
                List<UniteI> nonEmptyList = legion.Unites;

                if (nonEmptyList.Count > 0)
                {
                    Label lbl = new Label();
                    lbl.Content = "Il y a " + nonEmptyList.Count + " unités sur cette case : ";
                    unitInfoPanel.Children.Add(lbl);

                    foreach (Unite u in nonEmptyList)
                    {
                        StackPanel stack = getUnitDescription(u);
                        VueUniteI view = u.makeView();
                        //we add a reference to the unit in the stack
                        stack.Tag = view;
                        view.Description.BorderThickness = new Thickness(2);
                        view.Description.Child = stack;
                        view.Description.Margin = new Thickness(10);

                        unitInfoPanel.Children.Add(view.Description);
                        stack.MouseDown += unitStackPanel_MouseDown;
                    }
                }
                else
                {
                    Label lbl = new Label();
                    lbl.Content = "Aucune unité sur cette case";
                    unitInfoPanel.Children.Add(lbl);
                }
            }
            else
            {
                Label lbl = new Label();
                lbl.Content = "Aucune unité sur cette case";
                unitInfoPanel.Children.Add(lbl);
            }
        }

        /**
        * Called when a unit is clicked in the stack panel 
        */
        private void unitStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var stack = sender as StackPanel;

            selectUnit(stack);

            if (_selectedUnit != null){
                var u = _selectedUnit.Tag as VueUniteI;
            }

            e.Handled = true;
        }

        /**
        * Select the unit according to the object selected
        */
        private void selectUnit(StackPanel selectedUnit)
        {
            if (_selectedUnit != null)
            {

                Border parent = (Border)_selectedUnit.Parent;
                parent.BorderThickness = new Thickness(2);
                foreach (Label lbl in _selectedUnit.Children)
                    lbl.FontWeight = FontWeights.Normal;

                NbTurnsLeft.Content = "Tours restants : " + partie.NombreTours;
                Units1Label.Content = "Tour : " + partie.Joueurs[0].Turn;
                Units2Label.Content = "Tour : " + partie.Joueurs[1].Turn;
                Points1Label.Content = "Points : " + partie.Joueurs[0].Points;
                Points2Label.Content = "Points : " + partie.Joueurs[1].Points;
                
            }

            var view = selectedUnit.Tag as VueUniteI;
            /*
            * Evite la sélection d'une unité par le joueur adverse lors du changement de tour
            */
           
                if (selectedUnit != _selectedUnit)
                {
                    Border parent = (Border)selectedUnit.Parent;
                    parent.BorderThickness = new Thickness(3);
                    foreach (Label lbl in selectedUnit.Children)
                        lbl.FontWeight = FontWeights.Bold;

                    _selectedUnit = selectedUnit;
                }
                else
                    _selectedUnit = null;
                view.mouseLeftButtonDown();
          
        }

        /*
            * Return a stack panel containing a graphical description of the unit
        */
        private StackPanel getUnitDescription(Unite u)
        {
            StackPanel stack = new StackPanel();
            stack.Orientation = Orientation.Horizontal;
            if (u.Deplacement > 0)
                stack.Background = new SolidColorBrush(Colors.Beige);
            else
                stack.Background = new SolidColorBrush(Colors.DarkGray);

            Label lbLife = new Label();
            lbLife.Content = "Vie : " + u.Vie;
            Label lbPoint = new Label();
            lbPoint.Content = "Points : " + u.rapporterPoints();
            Label lbOff = new Label();
            lbOff.Content = "Attaque : " + u.Attaque;
            Label lbDeff = new Label();
            lbDeff.Content = "Defense : " + u.Defense;

            stack.Children.Add(lbLife);
            stack.Children.Add(lbPoint);
            stack.Children.Add(lbOff);
            stack.Children.Add(lbDeff);

            return stack;
        }

        private bool hasUnits(int line, int column)
        {
            //trouver la présence d'unités
            return true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveAs win = new SaveAs(partie);
            win.Show();
        }
    }
}
