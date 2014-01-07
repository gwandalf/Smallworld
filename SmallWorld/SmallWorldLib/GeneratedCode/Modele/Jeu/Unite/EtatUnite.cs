using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Modele.Jeu.Unit
{
    [XmlInclude(typeof(TourAdverse))]
    [XmlInclude(typeof(Jouable))]
    [XmlInclude(typeof(NonJouable))]
    [XmlInclude(typeof(Morte))]
    [XmlInclude(typeof(Initial))]
    [Serializable]
    public abstract class EtatUnite : EtatUniteI
    {
        protected UniteI unite;
        [XmlIgnoreAttribute]
        public UniteI Unite
        {
            get { return unite; }
            set { unite = value; }
        }

        protected Boolean turn;
        public virtual Boolean Turn
        {
            set
            {
                turn = value;
            }
        }

        protected AutomateUniteI automate;
        [XmlIgnoreAttribute]
        public AutomateUniteI Automate
        {
            get { return automate; }
            set { automate = value; }
        }

        public EtatUnite()
        {
        }

        public EtatUnite(UniteI u, AutomateUniteI au)
        {
            unite = u;
            automate = au;
            turn = false;
        }

        public virtual void arrivee()
        {
        }

        public virtual void selectionner()
        {
        }

        public virtual void deplacement()
        {
        }

        public virtual void mourir()
        {
            automate.Courant = automate.Morte;
        }
    }
}
