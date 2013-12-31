using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class NonJouable : EtatUnite
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

        public NonJouable(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

        public override void arrivee()
        {
            unite.Joueur.NbUnitesJouables--;
        }
    }
}
