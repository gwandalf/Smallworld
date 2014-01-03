using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;

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
                {
                    unite.Deplacement = Modele.Jeu.Unite.DEPL;
                    automate.Courant = automate.TourAdverse;
                    unite.Joueur.NbUnitesNonJouables--;
                }
            }
        }

        public NonJouable(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

        public override void arrivee()
        {
            unite.Joueur.NbUnitesNonJouables++;
        }

    }
}
