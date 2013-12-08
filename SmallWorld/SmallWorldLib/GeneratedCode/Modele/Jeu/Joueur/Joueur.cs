﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu.Joueur
{
	using Modele.Creation;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

    /**
     * \class Joueur
     * 
     * \brief Represents players of the game
     * 
     */
	public class Joueur : JoueurI
	{
        //number of points
		private int points
		{
			get;
			set;
		}

        //indicates if the instance is the one who plays the first round
		private bool premier
		{
			get;
			set;
		}

        //instances of Unite that are in the current instance of Joueur army
		private List<UniteI> unites;
        private List<Unite> Unites
		{
			get;
			set;
		}

        //state machine describing the current instance
        private AutomateJoueur Automate
        {
        }

        /**
         * \fn public Joueur(List<UniteI> unites)
         * \brief constructor
         * 
         * \param[in, out] unites : the army of the player is initialized, the player is set as the player of the unites
         * 
         */
        public Joueur(List<UniteI> unites)
		{
            this.unites = unites;
            foreach (UniteI unite in this.unites)
                this.unites[this.unites.Count].defineJoueur(this);
		}

        /**
         * \fn public virtual void passerMain()
         * \brief the current player can play now
         * 
         */
        public virtual void passerMain()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public virtual int nbUnitesJouables()
         * \brief how many unites can be played ?
         * 
         * \return int : the number of unites that can be played
         */
        public virtual int nbUnitesJouables()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public virtual void passerMain(JoueurI adversaire)
         * \brief the player "adversaire" can play now
         * 
         * \param[in, out] adversaire : the state of "adversaire" switches to "Tour"
         * 
         */
        public virtual void passerMain(JoueurI adversaire)
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public virtual int nbUnitesJouables()
         * \brief Who is the winner ?
         * 
         * \param[in, out] adversaire : the state of "adversaire" switches to "Perdant" or "Gagnant"
         * 
         * \return bool : true if the current player is the winner, else returns false
         */
        public virtual bool aVaincu(JoueurI adversaire)
		{
			throw new System.NotImplementedException();
		}

		public virtual void fin()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public virtual bool unitesSelectionnables(int lig, int col)
         * \brief Are there selectionable unites in the specified case ?
         * 
         * \param[in] lig : line of the case
         * \param[in] col : column of the case
         * 
         * \return bool : true if the current player has selectionnable unites in the specified case
         */
        public virtual bool unitesSelectionnables(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public List<UniteI> unite()
         * \brief return the army of the current player
         * 
         */
        public virtual List<UniteI> unite()
        {
            return unites;
        }

	}
}

