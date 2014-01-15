using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Interfaces.Modele.Jeu.Unit;

namespace Implementation.Modele.Jeu.Unit
{
    /// <summary>
    /// abstraction of a state
    /// </summary>
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

        //event if the turn switches
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

        //the default behaviour is to do nothing. That is why the methods are not abstracts.

        //event at the arrival in the state
        public virtual void arrivee()
        {
        }

        //event if the user tries to select the unit
        public virtual void selectionner()
        {
        }

        //event if a move is performed
        public virtual void deplacement()
        {
        }

        /// <summary>
        /// whatever the sate is, if a unit dies, it goes to the corresponding state
        /// </summary>
        public virtual void mourir()
        {
            automate.Courant = automate.Morte;
        }
    }
}
