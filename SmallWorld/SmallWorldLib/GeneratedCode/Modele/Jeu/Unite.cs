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

    /**
     * \class Unite
     * 
     * \brief Represents unites of the game
     * 
     */
	public abstract class Unite : UniteI
	{
		protected int vie;
        public virtual int Vie
		{
			get;
			set;
		}

		protected int deplacement;
        public virtual int Deplacement
		{
			get;
			set;
		}

        protected int attaque;
        public virtual int Attaque
        {
            get;
            set;
        }

        protected int defense;
        public virtual int Defense
        {
            get;
            set;
        }

        protected JoueurI joueur;
        public virtual JoueurI Joueur
        {
			get;
			set;
		}

        protected CarteI carte;
        public virtual CarteI Carte
        {
            get;
            set;
        }
        /*
		public virtual Etat etat
		{
			get;
			set;
		}*/

        /**
         * \fn public Unite()
         * \brief constructor
         * 
         * All unites have 2HP, 1 moving point, 2 attack points, 1 defensive point
         * 
         */
        public Unite()
        {
            vie = 2;
            deplacement = 1;
            attaque = 2;
            defense = 1;
        }


		public virtual void selectionner()
		{
			throw new System.NotImplementedException();
		}

		public virtual int verifPointsDeplacement()
		{
			throw new System.NotImplementedException();
		}

		public virtual void deplacer(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual void attaquer(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual List<Tuple<int,int>> getChoixCases()
		{
			throw new System.NotImplementedException();
		}

		public virtual List<Tuple<int,int>> deplacementsPossibles()
		{
			throw new System.NotImplementedException();
		}

		public virtual void engagement(UniteI defenseur)
		{
			throw new System.NotImplementedException();
		}

		public virtual int getNbTours(UniteI defenseur)
		{
			throw new System.NotImplementedException();
		}

		public virtual UniteI combat(UniteI defenseur)
		{
			throw new System.NotImplementedException();
		}

		public virtual void afficher()
		{
			throw new System.NotImplementedException();
		}

		public abstract int rapporterPoints();

        /**
         * \fn public virtual void defineCarte(CarteI carte)
         * \brief set the map passes by parameter
         * 
         * param[in] carte : the map on which is placed the unite
         * 
         */
        public virtual void defineCarte(CarteI carte)
        {
            this.carte = carte;
        }

        /**
         * \fn void defineJoueur(JoueurI joueur)
         * \brief set the player
         * 
         * param[in] player : player the unite belongs to
         * 
         */
        public void defineJoueur(JoueurI joueur)
        {
            this.Joueur = joueur;
        }

	}
}

