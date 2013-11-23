using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Joueur
{
    public abstract class EtatJoueur
    {
        protected AutomateJoueur automate
        {
            get;
            set;
        }

        //TODO ajouter toutes les methodes qui font changer d'etat.
        //TODO patron Observateur ?

        /*public ... methodeSortie(params) {
         *  automate.changerEtat(automate.NouvelEtat);
         * }
         * 
         * constructeur des classes filles :
         * public Constructeur() {
         *  traitements...
         * }
         */

    }
}
