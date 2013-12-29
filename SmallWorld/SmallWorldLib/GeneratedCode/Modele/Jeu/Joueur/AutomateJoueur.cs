using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modele.Jeu.Joueur
{
    /**
     * \class AutomateJoueur
     * \brief state machine corresponding to the player
     * 
     * contains an example of each possible state and a current state
     * Only delegates the method to the current state
     * Provides the getters and setters used to switch of state
     * 
     */
    public class AutomateJoueur// : JoueurI
    {/*
        //reference
        private JoueurI joueur;
        public JoueurI Joueur
        {
            get { return joueur; }
        }

        //examples of states
        private Gagnant winner;
        public Gagnant Winner
        {
            get
            {
                if (winner == null)
                    winner = new Gagnant(this);
                return winner;
            }
        }

        private Perdant looser;
        public Perdant Looser
        {
            get
            {
                if (looser == null)
                    looser = new Perdant(this);
                return looser;
            }
        }

        private Tour myTurn;
        public Tour MyTurn
        {
            get
            {
                if (myTurn == null)
                    myTurn = new Tour(this);
                return myTurn;
            }
        }

        private TourAdverse hisTurn;
        public TourAdverse HisTurn
        {
            get
            {
                if (hisTurn == null)
                    hisTurn = new TourAdverse(this);
                return hisTurn;
            }
        }

        //current state
        private EtatJoueur etat;
        public EtatJoueur Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public AutomateJoueur(JoueurI j)
        {
            joueur = j;
        }*/
    }
}
