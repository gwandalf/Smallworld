namespace Implementation.Modele.Jeu
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Interfaces.Modele.Jeu;


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
            get { return points; }
            set { points = value; }
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
        }
    }
}
