using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public abstract class EtatUnite : EtatUniteI
    {
        protected UniteI unite;
        public UniteI Unite
        {
            get { return unite; }
        }

        protected Boolean turn;
        public virtual Boolean Turn
        {
            set
            {
                turn = value;
            }
        }

        protected AutomateUniteI automate;

        public EtatUnite()
        {
        }

        public EtatUnite(UniteI u, AutomateUniteI au)
        {
            unite = u;
            automate = au;
            turn = false;
        }

        public virtual void arrivee()
        {
        }

        public virtual void selectionner()
        {
        }

        public virtual void deplacement()
        {
        }

        public virtual void mourir()
        {
            automate.Courant = automate.Morte;
        }
    }
}
