﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    [Serializable]
    public class TourAdverse : EtatUnite
    {
        public override Boolean Turn
        {
            set
            {
                //when the turn switches, the new state is "playable"
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
