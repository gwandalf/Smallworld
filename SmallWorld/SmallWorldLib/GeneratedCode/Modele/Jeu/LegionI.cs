using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu.Unit;

namespace Modele.Jeu
{
    public interface LegionI
    {
        //Units of the legion
        List<UniteI> Unites
        {
            get;
            set;
        }

        //line number of the position of the legion
        int Ligne
        {
            get;
            set;
        }

        //column number of the position of the legion
        int Colonne
        {
            get;
            set;
        }
    }
}
