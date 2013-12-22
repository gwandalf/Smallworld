using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF
{
    class ImageFactory
    {
        private ImageBrush mountain;
        private ImageBrush forest;
        private ImageBrush lowland;
        private ImageBrush desert;
        private ImageBrush sea;

        public ImageFactory()
        {
            BitmapImage _seaImage = new BitmapImage(new Uri(@"../textures/terrains/neige.png", UriKind.Relative));
            sea = new ImageBrush();
            sea.ImageSource = _seaImage;

            BitmapImage _lowlandImage = new BitmapImage(new Uri(@"../textures/terrains/plaine.png", UriKind.Relative));
            lowland = new ImageBrush();
            lowland.ImageSource = _lowlandImage;

            BitmapImage _mountainImage = new BitmapImage(new Uri(@"../textures/terrains/montagne.png", UriKind.Relative));
            mountain = new ImageBrush();
            mountain.ImageSource = _mountainImage;

            BitmapImage _desertImage = new BitmapImage(new Uri(@"../textures/terrains/desert.png", UriKind.Relative));
            desert = new ImageBrush();
            desert.ImageSource = _desertImage;

            BitmapImage _forestImage = new BitmapImage(new Uri(@"../textures/terrains/forest.png", UriKind.Relative));
            forest = new ImageBrush();
            forest.ImageSource = _forestImage;     
        }

        public ImageBrush getImageBrush(Tile t)
        {
            ImageBrush image = null;
            switch (t)
            {
                case Tile.DESERT:
                    image = desert;
                    break;
                case Tile.FOREST:
                    image = forest;
                    break;
                case Tile.LOWLAND:
                    image = mountain;
                    break;
                case Tile.MOUTAIN:
                    image = lowland;
                    break;
                case Tile.SEA:
                    image = sea;
                    break;
                default:
                    break;
            }
            return image;
        }
    }
}
