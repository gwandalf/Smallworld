using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Unit
{
    public interface EtatUniteI
    {
        UniteI Unite
        {
            get;
        }

        Boolean Turn
        {
            set;
        }

        void selectionner();
    }
}
