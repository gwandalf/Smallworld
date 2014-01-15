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
using System.Windows.Shapes;
using Implementation.Modele.Creation;
using Implementation.Modele.Jeu;
using Implementation.Modele.Jeu.Unit;
using Interfaces.Modele.Creation;
using Interfaces.Modele.Jeu;

namespace WPF
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameInitiator game;
        private List<FabriqueI> fabriques;
        private MonteurPartieI mp;

        public PartieI PARTY;

        public MainWindow()
        {

            //initialisation of the elements used to build the party
            game = GameInitiator.INSTANCE;
            fabriques = new List<FabriqueI>(2);
            fabriques.Add(null);
            fabriques.Add(null);
        }

        private void StartUpButton_Click(object sender, RoutedEventArgs e)
        {
            //We start the game only if both nations and difficulty are selected.
            bool fabValide = true;
            bool montValide = (mp != null);
            foreach (FabriqueI f in fabriques)
                fabValide = fabValide && (f != null);
            if (fabValide && montValide)
            {
                game.FabriquesUnite = fabriques;
                game.MonteurPartie = mp;
                PartieI partie = game.creerPartie();
                Map win = new Map(partie, labelPlayer1.Text, labelPlayer2.Text);
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(this,
                    "Erreur du jeu, fabrique = " + fabValide + ", monteur = " + montValide,
                    "Type de jeu non reconnu",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void labelPlayer1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (labelPlayer1.Text == "Joueur 1")
                labelPlayer1.Text = "";
        }

        private void labelPlayer2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (labelPlayer2.Text == "Joueur 2")
                labelPlayer2.Text = "";
        }
        private void labelPlayer1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (labelPlayer1.Text == "")
                labelPlayer1.Text = "Joueur 1";
        }

        private void labelPlayer2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (labelPlayer2.Text == "")
                labelPlayer2.Text = "Joueur 2";
        }

        private void Nain1_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[0] = new Fabrique<Nain>();
        }

        private void Gaul1_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[0] = new Fabrique<Gaulois>();
        }

        private void Viking1_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[0] = new Fabrique<Viking>();
        }

        private void Nain2_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[1] = new Fabrique<Nain>();
        }

        private void Gaul2_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[1] = new Fabrique<Gaulois>();
        }

        private void Viking2_Selected(object sender, RoutedEventArgs e)
        {
            fabriques[1] = new Fabrique<Viking>();
        }

        private void DemoItem_Selected(object sender, RoutedEventArgs e)
        {
            mp = new MonteurPartieDemo();
        }

        private void SmallItem_Selected(object sender, RoutedEventArgs e)
        {
            mp = new MonteurPartiePetite();
        }

        private void NormalItem_Selected(object sender, RoutedEventArgs e)
        {
            mp = new MonteurPartieNormale();
        }

        private void ChargerButton_Click(object sender, RoutedEventArgs e)
        {
            Load win = new Load(this);
            win.Show();
        }
    }
}