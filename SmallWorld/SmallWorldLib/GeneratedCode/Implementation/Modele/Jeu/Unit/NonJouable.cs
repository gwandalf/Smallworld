using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    [Serializable]
    public class NonJouable : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                turn = value;
                if (!turn)
                {
                    unite.Deplacement = Implementation.Modele.Jeu.Unit.Unite.DEPL;
                    automate.Courant = automate.TourAdverse;
                    unite.Joueur.NbUnitesNonJouables--;
                }
            }
        }

        public NonJouable()
            : base()
        {

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
