﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Implementation.Modele.Jeu
{
	using Modele.Creation;
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using Interfaces.Modele.Jeu;
    using Interfaces.Modele.Jeu.Unit;

	public class Partie : PartieI
	{
		private int nombreTours;
        public int NombreTours
		{
            get { return nombreTours; }
            set { nombreTours = value; }
		}

        private List<Joueur> joueurs;
        public List<Joueur> Joueurs
		{
			get{return joueurs;}
			set{joueurs = value;}
		}

        private CarteCS carte;
		public CarteCS Carte
		{
            get { return carte; }
            set { carte = value; }
		}

        private JoueurI gagnant;
        public JoueurI Gagnant
        {
            get { return gagnant; }
        }

        //index of the first player
        private int first;
        public int First
        {
            get { return first; }
            set { first = value; }
        }

        //index of the current player
        private int current;
        public int Current
        {
            get { return current; }
            set { current = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public Partie()
        {

        }

        /**
         * \fn public Partie(List<JoueurI> joueurs, int nbTours, CarteI carte)
         * \brief Constructor of a party
         * 
         * param[in] joueurs : players
         * param[in] nbTours : number of rounds
         * param[in] carte : map
         * 
         */
        public Partie(List<Joueur> joueurs, int nbTours, CarteCS carte)
		{
            this.joueurs = joueurs;
            foreach (Joueur j in joueurs)
                j.PropertyChanged += new PropertyChangedEventHandler(update);
            this.nombreTours = nbTours;
            this.carte = carte;

            //decides which player is the first
            Random rand = new Random();
            first = rand.Next(0, 2);
            current = first;
            this.joueurs[first].Turn = true;
		}

        /// <summary>
        /// the method allow to figure out who is the winner
        /// </summary>
        /// <returns> the winner or null if there is no winner yet </returns>
        public virtual JoueurI determinerGagnant()
		{
            if (nombreTours == 0)
            {
                return determinerMeneur();
            }
            else
            {
                return determinerSurvivant();
            }
		}

        /// <summary>
        /// finds out if a player is "dead"
        /// </summary>
        /// <returns> the winner if there is one, else null </returns>
        public JoueurI determinerSurvivant()
        {
            JoueurI gagnant = null;
            int i = 0;
            while (i < joueurs.Count)
            {
                if (joueurs[i].Unites.Count > 0)
                {
                    if (gagnant == null) //a player is alive ? Maybe it's the winner...
                        gagnant = joueurs[i];
                    else //it means that both are alive, so there is not a winner yet
                    {
                        gagnant = null;
                        break;
                    }
                }
            }
            return gagnant;
        }

        /// <summary>
        /// finds out which player have the greatest amount of points
        /// </summary>
        /// <returns> the winner </returns>
        public JoueurI determinerMeneur()
        {
            JoueurI gagnant = joueurs[0];
            for (int i = 1; i < joueurs.Count; i++)
            {
                if (joueurs[i].Points > gagnant.Points)
                    gagnant = joueurs[i];
            }
            return gagnant;
        }

        //when a player ends his turn, he notifies the game, which switches the turns
        public void update(object sender, PropertyChangedEventArgs e)
        {
            finTour();
        }

        /// <summary>
        /// switches the turn or end the game if there is a winner
        /// </summary>
        public virtual void finTour()
        {
            if (gagnant == null)
            {
                int former = current;
                current = (current + 1) % joueurs.Count;

                //decrements the number of turns if both players played their turn
                if (current == first)
                    nombreTours--;
                JoueurI winner = determinerGagnant();

                //if there is not a winner, the turn switches
                if (winner == null)
                    joueurs[former].passerMain(joueurs[current]);

                    //else, the result is shown
                else
                {
                    joueurs[former].Turn = false;
                    gagnant = winner;
                    OnPropertyChanged("Gagnant");
                }
            }

        }

	}
}

