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
using Modele.Jeu;
using Modele.Creation;
using Wrapper;

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
        StackPanel _selectedUnit;
        
        public Map(PartieI p, string nameP1, string nameP2)
        {
            InitializeComponent();/*
            List<FabriqueI> fi = new List<FabriqueI>(2);
            fi.Add(createFabrique(nation1));
            fi.Add(createFabrique(nation2));
            
            switch (mapType)
            {
                case GameType.DEMO:
                    mp = new MonteurPartieDemo();
                    break;

                case GameType.SMALL:
                    mp = new MonteurPartiePetite();
                    break;

                case GameType.NORMAL:
                    mp = new MonteurPartieNormale();
                    break;

                default:
                    MessageBox.Show(this, "Type de jeu non reconnu", "Erreur du jeu", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                    break;
            }*/
            partie = p;

            partie.start();
           
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
                    //a remplacer par un truc du genre map.get(l , c) et qui renvoit le type de la case
                    CaseI tile = map.Cases[l][c]; 
   
                    var rect = createRectangle(l, c, tile);
                    mapGrid.Children.Add(rect);
                }
            }
            //updateUnitUI();
           
        }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="c"></param>
            /// <param name="l"></param>
            /// <param name="tile"></param>
            /// <returns></returns>
            private Rectangle createRectangle(int c, int l, CaseI tile)
            {
                var rectangle = new Rectangle();
                rectangle.Fill = tile.Image;

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
               // Je ne sais pas comment faire là dedans,
               // De ce que j'ai compris, il faut dire  à la "Grid" qu'elle a été mise à jour, pour afficher les cases...
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                var rectangle = sender as Rectangle;
                var tile = rectangle.Tag as Case;
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

                if (_selectedUnit != null)
                {
                    // On veut se déplacer ou attaquer
                    perform_action(row, column);
                }
                //mise à jour des infos, de l'écran
                //update()

                e.Handled = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="row"></param>
            /// <param name="column"></param>
            private void perform_action(int row, int column)
            {
               
            }
    }
}
