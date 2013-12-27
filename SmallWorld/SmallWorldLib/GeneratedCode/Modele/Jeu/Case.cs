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
        protected ImageBrush image;
        public ImageBrush Image
        {
            get { return image; }
            set { image = value; }
        }

        public Case()
        {
        }
    }
}
