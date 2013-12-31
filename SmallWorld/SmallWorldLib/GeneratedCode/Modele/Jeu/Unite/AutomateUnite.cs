using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;

namespace Modele.Jeu.Unit
{
    /**
     * \class AutomateJoueur
     * \brief state machine corresponding to the player
     * 
     * contains an example of each possible state and a current state
     * Only delegates the method to the current state
     * Provides the getters and setters used to switch of state
     * 
     */
    public class AutomateUnite : AutomateUniteI
    {
        private UniteI unite;
        public UniteI Unite
        {
            get { return unite; }
        }

        private EtatUniteI jouable;
        public EtatUniteI Jouable
        {
            get
            {
                if (jouable == null)
                    jouable = new Jouable(unite, this);
                return jouable;
            }
        }

        private EtatUniteI nonJouable;
        public EtatUniteI NonJouable
        {
            get
            {
                if (nonJouable == null)
                    nonJouable = new NonJouable(unite, this);
                return nonJouable;
            }
        }

        private EtatUniteI tourAdverse;
        public EtatUniteI TourAdverse
        {
            get
            {
                if (tourAdverse == null)
                    tourAdverse = new TourAdverse(unite, this);
                return tourAdverse;
            }
        }

        private EtatUniteI morte;
        public EtatUniteI Morte
        {
            get
            {
                if (morte == null)
                    morte = new Morte(unite, this);
                return morte;
            }
        }

        private EtatUniteI courant;
        public EtatUniteI Courant
        {
            get { return courant; }
            set { courant = value; }
        }

        private Boolean turn;
        public Boolean Turn
        {
            set
            {
                turn = value;
                courant.Turn = value;
            }
        }

        public AutomateUnite(UniteI u)
        {
            unite = u;
            turn = false;
            courant = new Initial(u, this);
        }

        public virtual void selectionner()
        {
            courant.selectionner();
        }

        public void deplacement()
        {
            courant.deplacement();
        }
    }
}
