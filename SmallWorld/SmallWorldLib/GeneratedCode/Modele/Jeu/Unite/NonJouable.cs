using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class NonJouable : EtatUnite
    {
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
