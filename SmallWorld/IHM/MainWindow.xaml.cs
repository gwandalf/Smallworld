using System;
using System.IO;
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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var stream = new FileStream("C:\\Users\\Eric\\Documents\\GitHub\\Smallworld\\SmallWorld\\textures\\terrains\\montagne.png", FileMode.Open, FileAccess.Read); 
            var bitmap = new BitmapImage(); 
            bitmap.BeginInit(); 
            bitmap.StreamSource = stream; 
            bitmap.EndInit(); 
            img2.Source = bitmap; 

            /*
            MemoryStream ms = new MemoryStream();
            FileStream stream = new FileStream("C:\\Users\\Eric\\Documents\\GitHub\\Smallworld\\SmallWorld\\textures\\terrains\\montagne.png", FileMode.Open, FileAccess.Read);
            ms.SetLength(stream.Length);
            stream.Read(ms.GetBuffer(), 0, (int)stream.Length);

            ms.Flush();
            stream.Close();

            Image i = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.StreamSource = ms;
            src.EndInit();
            i.Source = src;
            i.Stretch = Stretch.Uniform;
            panel.Children.Add(i);
             */

            /*
            //Uri _imageUri = new Uri(imageAbsolutePath);
            //ImageXamlElement.Source = _imageUri.GetBitmapImage(BitmapCacheOption.OnLoad);
            Image i = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("C:\\Users\\Eric\\Documents\\GitHub\\Smallworld\\SmallWorld\\textures\\terrains\\montagne.png", UriKind.Relative);
            src.CacheOption = BitmapCacheOption.OnLoad;
            src.EndInit();
            i.Source = src;
            i.Stretch = Stretch.Uniform;
            //int q = src.PixelHeight;        // Image loads here
            sp.Children.Add(i);
            */
        }
        /*
        public static BitmapImage GetBitmapImage(
            this Uri imageAbsolutePath,
             BitmapCacheOption bitmapCacheOption = BitmapCacheOption.Default)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.CacheOption = bitmapCacheOption;
            image.UriSource = imageAbsolutePath;
            image.EndInit();

            return image;
        }
         */
    }
}
