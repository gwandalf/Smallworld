using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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
    [Serializable]
    public class AutomateUnite : AutomateUniteI
    {
        private UniteI unite;
        [XmlIgnoreAttribute]
        public UniteI Unite
        {
            get { return unite; }
        }

        private EtatUnite jouable;
        [XmlIgnoreAttribute]
        public EtatUnite Jouable
        {
            get
            {
                if (jouable == null)
                    jouable = new Jouable(unite, this);
                return jouable;
            }
        }

        private EtatUnite nonJouable;
        [XmlIgnoreAttribute]
        public EtatUnite NonJouable
        {
            get
            {
                if (nonJouable == null)
                    nonJouable = new NonJouable(unite, this);
                return nonJouable;
            }
        }

        private EtatUnite tourAdverse;
        [XmlIgnoreAttribute]
        public EtatUnite TourAdverse
        {
            get
            {
                if (tourAdverse == null)
                    tourAdverse = new TourAdverse(unite, this);
                return tourAdverse;
            }
        }

        private EtatUnite morte;
        [XmlIgnoreAttribute]
        public EtatUnite Morte
        {
            get
            {
                if (morte == null)
                    morte = new Morte(unite, this);
                return morte;
            }
        }

        private EtatUnite courant;
        public EtatUnite Courant
        {
            get { return courant; }
            set 
            {
                courant = value;
                courant.arrivee();
            }
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

        public AutomateUnite()
        {
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

        public void mourir()
        {
            courant.mourir();
        }
    }
}
