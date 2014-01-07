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
    using Modele.Jeu.Unit;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

    /**
     * \class Unite
     * 
     * \brief Represents unites of the game
     * 
     */
    [XmlInclude(typeof(Gaulois))]
    [XmlInclude(typeof(Viking))]
    [XmlInclude(typeof(Nain))]
    [Serializable]
	public abstract class Unite : UniteI/*, INotifyPropertyChanged*/
	{

        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\zelda.png", UriKind.Relative)));
        public static int DEPL = 3;

        protected ImageBrush icon;
        public ImageBrush Icon
        {
            get { return icon; }
        }

        protected int id;
        public int ID
        {
            get { return id; }
        }

		protected int vie;
        public int Vie
		{
            get { return vie; }
            set 
            { 
                vie = value;
                if (vie == 0)
                {
                    automate.mourir();
                }
            }
		}

		protected int deplacement;
        public int Deplacement
		{
            get { return deplacement; }
            set 
            { 
                deplacement = value;
                if (value == 0)
                    automate.deplacement();
            }
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
        [XmlIgnoreAttribute]
        public JoueurI Joueur
        {
            get { return joueur; }
            set { joueur = value; }
		}

        protected CarteI carte;
        [XmlIgnoreAttribute]
        public CarteI Carte
        {
            get { return carte; }
            set { carte = value; }
        }
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }*/

        protected AutomateUnite automate;
        public AutomateUnite Automate
        {
            get { return automate; }
            set { automate = value; }
        }

        protected Boolean turn;
        public Boolean Turn
        {
            get { return turn; }
            set 
            {
                turn = value;
                automate.Turn = value;
            }
        }

        //the position of the unit on the map
        [XmlIgnoreAttribute]
        public Tuple<int, int> Position
        {
            get
            {
                Tuple<int, int> pos;
                carte.PositUnite.TryGetValue(this, out pos);
                return pos;
            }

            set
            {
                this.Carte.PositUnite.Remove(this);
                this.Carte.PositUnite.Add(this, value);
            }
        }

        //legion of the current unit
        protected Legion legion;
        public Legion Legion
        {
            get { return legion; }
            set { legion = value; }
        }

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
            deplacement = DEPL;
            attaque = 2;
            defense = 1;
            icon = ICON;
            turn = false;
            legion = null;
        }


		public virtual void selectionner()
		{
            automate.selectionner();
		}

		public virtual void deplacer(int lig, int col)
		{
            int distance = deplacementPossible(lig, col);
            if (distance != -1)
            {
                setBonusMalusPoints(true); //the bonus and malus on the gains are activated
                joueur.Points -= rapporterPoints(); //the player loose the points related to the former position
                removeOfMap();
                placeOnMap(lig, col);
                Deplacement -= distance;
                setBonusMalusPoints(false); //the bonus and malus on the gains are desactivated
                legion.afficher(); //the views are notified for the view of unit to move on the map
            }
		}

        public virtual int deplacementPossible(int lig, int col)
        {
            Tuple<int, int> pos = Position;
            int res = Math.Abs(pos.Item1 - lig) + Math.Abs(pos.Item2 - col);
            if (res <= deplacement && carte.Cases[lig][col] != carte.Fabrique.Eau)
                return res;
            else
                return -1;
        }

        public virtual bool attaquePossible(int lig, int col)
        {
            Tuple<int, int> pos = Position;
            int distance = Math.Abs(pos.Item1 - lig) + Math.Abs(pos.Item2 - col);
            LegionI leg = carte.getLegion(lig, col);
            if (distance == 1 && leg != null && deplacementPossible(lig, col) != -1)
            {
                if (leg.Unites[0].Joueur != joueur)
                    return true;
            }
            return false;
        }

        //TODO doit etre modifiee : remplacer par l'algorithme du poly
		public virtual void attaquer(int lig, int col)
		{
            if (attaquePossible(lig, col))
            {
                LegionI leg = carte.getLegion(lig, col);
                leg.Unites[0].Vie = 0;
            }
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

        /// <summary>
        /// the method gives the number of points due to the unit
        /// </summary>
        /// <returns> points related to the actual position of the unite on the map </returns>
        public virtual int rapporterPoints()
        {
            Tuple<int, int> pos = Position;
            List<List<CaseI>> cases = carte.Cases;
            return cases[pos.Item1][pos.Item2].Points;
        }

        public virtual void removeOfMap()
        {
            this.Carte.PositUnite.Remove(this);
            legion.Unites.Remove(this);
            if (legion.Unites.Count == 0)
            {
                legion.detruireLegion();
                carte.Legions.Remove(legion);
                legion = null;
            }
        }

        /**
         * \fn void placeOnMap(int x, int y)
         * \brief put the current unite on its map at the specified position
         * 
         * param[in] x : column number
         * param[in] y : line number
         * 
         */
        public virtual void placeOnMap(int x, int y)
        {
            legion = (Legion)carte.getLegion(x, y);
            //if there is no legion at this position, we create one
            //else, we simmply add the unit to the found legion
            if (legion == null)
            {
                legion = new Legion(this, x, y);
                carte.ajouterLegion(legion);
            }
            else
                legion.Unites.Add(this);
            Tuple<int, int> t = new Tuple<int, int>(x, y);
            this.Carte.PositUnite.Add(this, t);
            joueur.Points += rapporterPoints(); //the player get the points related to the new position
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
            return res;
        }

        public abstract void setBonusMalusPoints(bool on);

	}
}

