using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public interface EtatUniteI
    {
        UniteI Unite
        {
            get;
        }

        Boolean Turn
        {
            set;
        }

        /**
         * \fn void arrivee();
         * \brief the Unite does the some operations at the entry of this state
         * 
         */
        void arrivee();

        void selectionner();

        void deplacement();
    }
}
