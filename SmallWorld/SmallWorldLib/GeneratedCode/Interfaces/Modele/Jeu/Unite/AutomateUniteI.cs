using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Implementation.Modele.Jeu.Unit;

namespace Interfaces.Modele.Jeu.Unit
{
    public interface AutomateUniteI
    {
        UniteI Unite
        {
            get;
            set;
        }

        EtatUnite Jouable
        {
            get;
        }

        EtatUnite NonJouable
        {
            get;
        }

        EtatUnite TourAdverse
        {
            get;
        }

        EtatUnite Morte
        {
            get;
        }

        EtatUnite Courant
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

        void mourir();
    }
}
