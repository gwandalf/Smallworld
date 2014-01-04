﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu
{
	using Modele.Creation;
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using System.Text;
    using System.ComponentModel;

	public class Partie : PartieI
	{
		private int nombreTours;
        public int NombreTours
		{
            get { return nombreTours; }
            set { nombreTours = value; }
		}

        private List<JoueurI> joueurs;
		public List<JoueurI> Joueurs
		{
			get{return joueurs;}
			set{if(value.Count == 2) joueurs = value;}
		}

        private CarteI carte;
		public CarteI Carte
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

        //index of the current player
        private int current;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
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
        public Partie(List<JoueurI> joueurs, int nbTours, CarteI carte)
		{
            this.joueurs = joueurs;
            foreach(JoueurI j in joueurs)
                j.PropertyChanged += new PropertyChangedEventHandler(update);
            this.nombreTours = nbTours;
            this.carte = carte;

            //decides which player is the first
            Random rand = new Random();
            first = rand.Next(0, 2);
            current = first;
            this.joueurs[first].Turn = true;
		}

		public virtual void afficherUnites(List<UniteI> unites)
		{
			throw new System.NotImplementedException();
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

        public JoueurI determinerSurvivant()
        {
            JoueurI gagnant = null;
            int i = 0;
            while (i < joueurs.Count)
            {
                if (joueurs[i].Unites.Count > 0)
                {
                    if (gagnant == null)
                        gagnant = joueurs[i];
                    else
                    {
                        gagnant = null;
                        break;
                    }
                }
            }
            return gagnant;
        }

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

        public void update(object sender, PropertyChangedEventArgs e)
        {
            finTour();
        }

        public virtual void finTour()
        {
            if (gagnant == null)
            {
                int former = current;
                current = (current + 1) % joueurs.Count;
                if (current == first)
                    nombreTours--;
                JoueurI winner = determinerGagnant();
                if (winner == null)
                    joueurs[former].passerMain(joueurs[current]);
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

