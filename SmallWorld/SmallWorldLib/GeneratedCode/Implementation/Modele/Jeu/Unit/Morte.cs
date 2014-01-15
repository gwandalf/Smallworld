using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    [Serializable]
    public class Morte : EtatUnite
    {

        public Morte()
            : base()
        {

        }

        public Morte(UniteI u, AutomateUniteI au)
            : base(u, au)
        {
        }

        public override void mourir()
        {
        }

        //whenever a unit dies, it is removed of the map
        public override void arrivee()
        {
            unite.removeOfMap();
        }
    }
}
