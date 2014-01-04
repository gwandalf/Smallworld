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
    public interface VueLegionI : AffichableI, INotifyPropertyChanged
    {
        //reference
        LegionI Legion
        {
            get;
            set;
        }

        ImageBrush Image
        {
            get;
            set;
        }
    }
}
