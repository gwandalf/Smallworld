using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace SmallWorldLib.GeneratedCode.Vue
{
    /**
     * \interface VueUniteI
     * 
     */
    public interface VueUniteI : AffichableI, INotifyPropertyChanged
    {

        UniteI Unite
        {
            get;
        }

        ImageBrush Image
        {
            get;
            set;
        }

    }
}
