using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SmallWorldLib.GeneratedCode.Vue
{
    /**
     * \class VueUnite
     * \brief view of a unite
     */
    public class VueUnite : VueUniteI
    {

        private UniteI unite;
        public UniteI Unite
        {
            get { return unite; }
        }

        private ImageBrush icon;
        public ImageBrush Image
        {
            get { return icon; }
            set { icon = value; }
        }

        public VueUnite(UniteI uRef)
        {
            unite = uRef;
        }
    }
}
