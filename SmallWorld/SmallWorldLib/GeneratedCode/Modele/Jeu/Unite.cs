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
    using SmallWorldLib.GeneratedCode.Vue;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /**
     * \class Unite
     * 
     * \brief Represents unites of the game
     * 
     */
	public abstract class Unite : UniteI/*, INotifyPropertyChanged*/
	{

        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\res\zelda.png", UriKind.Relative)));

        protected int id;
        public int ID
        {
            get { return id; }
        }

		protected int vie;
        public int Vie
		{
            get { return vie; }
            set { vie = value; }
		}

		protected int deplacement;
        public int Deplacement
		{
            get { return deplacement; }
            set { deplacement = value; }
		}

        protected int attaque;
        public int Attaque
        {
            get { return attaque; }
            set { attaque = value; }
        }

        protected int defense;
        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        protected JoueurI joueur;
        public JoueurI Joueur
        {
            get { return joueur; }
            set { joueur = value; }
		}

        protected CarteI carte;
        public CarteI Carte
        {
            get { return carte; }
            set { carte = value; }
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
            VueUniteI view = makeView();

		}

		public abstract int rapporterPoints();

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

        /**
         * \fn void placeOnMap(int x, int y)
         * \brief put the current unite on its map at the specified position
         * 
         * param[in] x : column number
         * param[in] y : line number
         * 
         */
        public void placeOnMap(int x, int y)
        {
            Tuple<int, int> t = new Tuple<int, int>(x, y);
            this.Carte.PositUnite.Add(this, t);
        }

        /**
         * \fn VueUniteI makeView()
         * \brief makes a view linked to the current unite
         * 
         * The corresponding icon is set to the view
         * 
         */
        public VueUniteI makeView()
        {
            VueUniteI res = new VueUnite(this);
            res.Image = ICON;
            return res;
        }

	}
}

