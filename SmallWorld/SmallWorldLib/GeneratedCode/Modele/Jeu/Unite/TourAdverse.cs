using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class TourAdverse : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                turn = value;
                if (turn)
                    automate.Courant = automate.Jouable;
            }
        }

        public TourAdverse()
            : base()
        {

        }

        public TourAdverse(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

    }
}
