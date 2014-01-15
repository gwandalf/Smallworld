using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    /// <summary>
    /// state of a unit which is in its turn but was already played
    /// </summary>
    [Serializable]
    public class NonJouable : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                //if the turn switches, the new state is "adversary's turn"
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

        //incrementation of a counter for the player to be notified when all of its units were played
        public override void arrivee()
        {
            unite.Joueur.NbUnitesNonJouables++;
        }

    }
}
