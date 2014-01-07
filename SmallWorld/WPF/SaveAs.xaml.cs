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
    /// <summary>
    /// Logique d'interaction pour SaveAs.xaml
    /// </summary>
    public partial class SaveAs : Window
    {
        private Partie partie;

        public SaveAs(Partie p)
        {
            InitializeComponent();
            partie = p;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Saver.INSTANCE.ToXML(partie, labelName.Text);
        }

        private void labelPlayer1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (labelName.Text == "Partie1")
                labelName.Text = "";
        }

        private void labelPlayer1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (labelName.Text == "")
                labelName.Text = "Partie1";
        }
    }
}
