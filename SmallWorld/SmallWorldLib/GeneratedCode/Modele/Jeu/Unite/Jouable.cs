using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class Jouable : EtatUnite
    {
        public Jouable(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
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
