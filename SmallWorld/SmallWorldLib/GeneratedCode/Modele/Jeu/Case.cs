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
        //Icon of the case
        protected ImageBrush image;
        public ImageBrush Image
        {
            get { return image; }
            set { image = value; }
        }

        //number of points given to the units which are on the case
        protected int points;
        public int Points
        {
            get;
            set;
        }

        //indicates if a unit can move or not on tihs case
        protected bool deplacement;
        public bool Deplacement
        {
            get;
            set;
        }

        /// <summary>
        /// default constructor
        /// points = 1
        /// deplacement = true
        /// </summary>
        public Case()
        {
            setDefault();
        }

        /// <summary>
        /// set default values of the attributes
        /// </summary>
        public virtual void setDefault()
        {
            points = 1;
            deplacement = true;
        }
    }
}
