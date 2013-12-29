using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;

namespace SmallWorldLib.GeneratedCode.Vue
{
    public interface VueCaseI : AffichableI
    {
        Tuple<int, int> Coord
        {
            get;
        }

        CarteI Carte
        {
            get;
        }
    }
}
