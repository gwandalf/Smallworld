using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class Jouable : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                turn = value;
                if (!turn)
                    automate.Courant = automate.TourAdverse;
            }
        }

        public Jouable(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

        public override void arrivee()
        {
            unite.Joueur.NbUnitesJouables = unite.Joueur.NbUnitesJouables + 1;
        }

        public override void sortie()
        {
            unite.Joueur.NbUnitesJouables = unite.Joueur.NbUnitesJouables - 1;
        }

        public override void selectionner()
        {
            unite.Carte.Selected = unite;
        }

        public override void deplacement()
        {
            automate.Courant = automate.NonJouable;
        }
    }
}
