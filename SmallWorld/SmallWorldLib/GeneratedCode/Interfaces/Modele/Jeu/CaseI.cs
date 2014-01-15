namespace Interfaces.Modele.Jeu
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        /// <summary>
        /// set default values of the attributes
        /// </summary>
        void setDefault();

    }
}
