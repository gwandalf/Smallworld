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

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour CreationPartie.xaml
    /// </summary>
    public partial class Carte : Window
    {
        public Carte()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            //var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            main.Left = this.Left;
            main.Top = this.Top;
           // this.Left = desktopWorkingArea.Right - this.Width;
            //this.Top = desktopWorkingArea.Bottom - this.Height;
            this.Close();
            main.Show();
        }
    }
}
