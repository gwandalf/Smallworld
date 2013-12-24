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
using Modele.Creation;
using Modele.Jeu;

namespace WPF
{
    public enum GameType : int
    {
        DEMO,
        NORMAL,
        SMALL,
    }
    public enum Nation : int
    {

        GAUL,
        NAIN,
        VIKING,
    }
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameInitiator game;
        private List<FabriqueI> fabriques;
        private MonteurPartieI mp;

        public MainWindow()
        {
            InitializeComponent();
            initializeMapTags();
            initializeNationTags();

            //initialisation of the elements used to build the party
            game = GameInitiator.INSTANCE;
            fabriques = new List<FabriqueI>(2);
            fabriques.Add(null);
            fabriques.Add(null);
        }

        private void initializeMapTags()
        {
            this.DemoItem.Tag = GameType.DEMO;
            this.SmallItem.Tag = GameType.SMALL;
            this.NormalItem.Tag = GameType.NORMAL;
        }

        private void initializeNationTags()
        {
            this.Nain1.Tag = Nation.NAIN;
            this.Nain2.Tag = Nation.NAIN;

            this.Gaul1.Tag = Nation.GAUL;
            this.Gaul2.Tag = Nation.GAUL;

            this.Viking1.Tag = Nation.VIKING;
            this.Viking2.Tag = Nation.VIKING;
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
                game.creerPartie();
            }
            /*
            //We start the game only if both nations are selected.
            if (ComboBoxNationPlayer1.SelectedIndex > -1 && ComboBoxNationPlayer2.SelectedIndex > -1)
            {
                // We retrieve game type with the tag
                ComboBoxItem itemGame = (ComboBoxItem)GameTypeComboBox.SelectedItem;
                ComboBoxItem itemNation1 = (ComboBoxItem)ComboBoxNationPlayer1.SelectedItem;
                ComboBoxItem itemNation2 = (ComboBoxItem)ComboBoxNationPlayer2.SelectedItem;

                Map win = new Map((GameType)itemGame.Tag, (Nation)itemNation1.Tag, (Nation)itemNation2.Tag, labelPlayer1.Text, labelPlayer2.Text);
                win.Show();
                this.Close();
            }
             * */
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
    }
}