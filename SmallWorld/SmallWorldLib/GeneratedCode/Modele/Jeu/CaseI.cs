namespace Modele.Jeu
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SmallWorldLib.GeneratedCode;

    public interface CaseI
    {
        //Icon of the case
        ImageBrush Image
        {
            get;
            set;
        }

        //number of points given to the units which are on the case
        int Points
        {
            get;
            set;
        }

        //indicates if a unit can move or not on tihs case
        bool Deplacement
        {
            get;
            set;
        }

    }
}
