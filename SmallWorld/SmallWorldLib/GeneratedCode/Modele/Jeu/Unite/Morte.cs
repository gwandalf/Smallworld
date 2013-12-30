using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public class Morte : EtatUnite
    {
        public Morte(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }
    }
}
