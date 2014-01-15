using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Controls;

namespace Interfaces.Vue
{
    /**
     * \interface VueUniteI
     * 
     */
    public interface VueUniteI : ComposantI
    {

        UniteI Unite
        {
            get;
        }

        Border Description
        {
            get;
            set;
        }

    }
}
