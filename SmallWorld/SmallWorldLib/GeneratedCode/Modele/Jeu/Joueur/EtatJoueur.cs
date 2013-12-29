using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Joueur
{
    public abstract class EtatJoueur : JoueurI
    {
        protected AutomateJoueur automate;
        public AutomateJoueur Automate
        {
            get { return automate; }
            set { automate = value; }
        }
    }
}
