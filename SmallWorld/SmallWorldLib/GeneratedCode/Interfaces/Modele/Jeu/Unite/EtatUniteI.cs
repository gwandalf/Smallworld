using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Modele.Jeu.Unit
{
    public interface EtatUniteI
    {
        UniteI Unite
        {
            get;
            set;
        }

        Boolean Turn
        {
            set;
        }

        AutomateUniteI Automate
        {
            get;
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

        void mourir();
    }
}
