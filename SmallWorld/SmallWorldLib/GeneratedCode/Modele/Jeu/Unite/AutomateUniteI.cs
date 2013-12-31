using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public interface AutomateUniteI
    {
        UniteI Unite
        {
            get;
        }

        EtatUniteI Jouable
        {
            get;
        }

        EtatUniteI NonJouable
        {
            get;
        }

        EtatUniteI TourAdverse
        {
            get;
        }

        EtatUniteI Morte
        {
            get;
        }

        EtatUniteI Courant
        {
            get;
            set;
        }

        Boolean Turn
        {
            set;
        }

        void selectionner();

        void deplacement();
    }
}
