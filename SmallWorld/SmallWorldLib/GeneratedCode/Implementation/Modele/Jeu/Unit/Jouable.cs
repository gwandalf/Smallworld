using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    //playable unit
    [Serializable]
    public class Jouable : EtatUnite
    {
        public override Boolean Turn
        {
            //if the turn switches to the adversary, the state become "adversary's turn"
            //all the move points are restored
            set
            {
                turn = value;
                if (!turn)
                {
                    unite.Deplacement = Implementation.Modele.Jeu.Unit.Unite.DEPL;
                    automate.Courant = automate.TourAdverse;
                }
            }
        }

        public Jouable()
            : base()
        {

        }

        public Jouable(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

        //in this state, a unit is selectionable
        public override void selectionner()
        {
            unite.Carte.Selected = unite;
            unite.suggerer();
        }

        //if a move is performed, the state switches to "unplayable"
        public override void deplacement()
        {
            automate.Courant = automate.NonJouable;
        }
    }
}
