using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Joueur
{
    public abstract class EtatJoueur //: JoueurI
    {
        protected AutomateJoueur automate;

        int Points
        {
            get;
            set;
        }

        //instances of Unite that are in the current instance of Joueur army
        List<UniteI> Unites
        {
            get;
            set;
        }

        bool Turn
        {
            get;
            set;
        }

        public EtatJoueur(AutomateJoueur automate)
        {
            this.automate = automate;
        }
    }
}
