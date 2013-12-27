namespace Modele.Jeu
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;


    public abstract class Case : CaseI
    {
        protected BitmapImage image;
        public BitmapImage Image
        {
            get { return image; }
        }

        public Case()
        {
        }
    }
}
