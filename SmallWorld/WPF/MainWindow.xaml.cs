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
using System.Windows.Rect;

namespace WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            loadImages();
        }

        public void loadImages()
        {
            Image img1 = new Image();
            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Users\Eric\Documents\GitHub\Smallworld\SmallWorld\textures\terrains\plaine.png");
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            img1.Source = myBitmapImage;
            //myImage.Source = myBitmapImage;

            //myImage.Source = new BitmapImage(new Uri(@"C:\Users\Eric\Documents\GitHub\Smallworld\SmallWorld\textures\terrains\plaine.png"));
        }

        // Override the OnRender call to add a Background and Border to the OffSetPanel
        protected override void OnRender(DrawingContext dc)
        {
            Image img1 = new Image();
            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(@"C:\Users\Eric\Documents\GitHub\Smallworld\SmallWorld\textures\terrains\plaine.png");
            myBitmapImage.DecodePixelWidth = 200;
            myBitmapImage.EndInit();
            //set image source
            img1.Source = myBitmapImage;
            dc.DrawImage(img1.Source, r1);
        }
    }
}
