using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modele.Jeu.Unit
{
    public class Initial : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                turn = value; 
                if (turn)
                    automate.Courant = automate.Jouable;
                else
                    automate.Courant = automate.TourAdverse;
            }
        }

        public Initial()
            : base()
        {
        }

        public Initial(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

    }
}
