using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    /// <summary>
    /// Initial state. It only moves the units of the different armies to their respective state : playable or waiting for their turn
    /// </summary>
    [Serializable]
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
