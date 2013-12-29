using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;

namespace SmallWorldLib.GeneratedCode.Vue
{
    public class VueCase : VueCaseI
    {
        private Tuple<int, int> coord;
        public Tuple<int, int> Coord
        {
            get { return coord; }
        }

        private CarteI carte;
        public CarteI Carte
        {
            get { return carte; }
        }

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        private ImageBrush icon;
        public ImageBrush Image
        {
            get { return icon; }
            set { icon = value; }
        }

        public VueCase(CarteI cRef, int l, int c)
        {
            carte = cRef;
            coord = new Tuple<int, int>(l, c);
        }

        public void mouseLeftButtonDown()
        {
            carte.deplacer(carte.Selected, coord.Item1, coord.Item2);
        }
    }
}
