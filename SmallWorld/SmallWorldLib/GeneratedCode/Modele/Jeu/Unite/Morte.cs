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

        public override void mourir()
        {
        }

        public override void arrivee()
        {
            unite.Joueur.Unites.Remove(unite);
            unite.Carte.PositUnite.Remove(unite);
            unite.Carte.UniteSet.Remove(unite);
        }
    }
}
