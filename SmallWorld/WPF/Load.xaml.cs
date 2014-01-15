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

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour Load.xaml
    /// </summary>
    public partial class Load : Window
    {
        private MainWindow mwin;

        public Load(MainWindow mwin)
        {
            InitializeComponent();
            this.mwin = mwin;
            for (int i = 0; i < Saver.INSTANCE.Files.Length; i++)
                Name.Items.Add(Saver.INSTANCE.Files[i]);
            if (Saver.INSTANCE.Files.Length >= 0)
                Name.SelectedIndex = 0;
        }

        private void ChargerButton_Click(object sender, RoutedEventArgs e)
        {
            Partie partie = Saver.INSTANCE.charger((string)Name.SelectedValue);
            Map win = new Map(partie, partie.Joueurs[0].Nom, partie.Joueurs[1].Nom);
            win.Show();
            mwin.Close();
            this.Close();
        }
    }
}
