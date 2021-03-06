﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Implementation.Modele.Jeu.Unit
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.ComponentModel;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Interfaces.Modele.Jeu.Unit;
    using Interfaces.Modele.Jeu;
    using Interfaces.Vue;
    using Implementation.Vue;
    using Implementation.Modele.Jeu;
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
	public abstract class Unite : UniteI
	{

        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\zelda.png", UriKind.Relative)));

        /// <summary>
        /// basic statistics
        /// </summary>
        public static int DEPL = 1;
        public static double VIE = 2.0;
        public static double ATTAQUE = 2.0;
        public static double DEFENSE = 1.0;

        protected ImageBrush icon;
        public ImageBrush Icon
        {
            get { return icon; }
        }

		protected double vie;
        public double Vie
		{
            get { return vie; }
            
            //the HP decrementation proportionaly affects power and defense
            set 
            {
                vie = value;
                attaque = (vie / VIE) * ATTAQUE;
                defense = (vie / VIE) * DEFENSE;

                //the unit automatically dies when it has 0 HP
                if (vie == 0.0)
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

        protected double attaque;
        public double Attaque
        {
            get { return attaque; }
            set { attaque = value; }
        }

        protected double defense;
        public double Defense
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
            vie = VIE;
            deplacement = DEPL;
            attaque = ATTAQUE;
            defense = DEFENSE;
            icon = ICON;
            turn = false;
            legion = null;
        }

        //on selection (delegated to the states-transition machine)
		public virtual void selectionner()
		{
            automate.selectionner();
		}

        /// <summary>
        /// move the unit to the specifed position
        /// </summary>
        /// <param name="lig"> x </param>
        /// <param name="col"> y </param>
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

        /// <summary>
        /// find out if the position is reachable
        /// By default, a unit can't walk on watter
        /// </summary>
        /// <param name="lig"> target line </param>
        /// <param name="col"> target column </param>
        /// <returns> distance if possible, else -1 </returns>
        public virtual int deplacementPossible(int lig, int col)
        {
            int res = Math.Abs(legion.Ligne - lig) + Math.Abs(legion.Colonne - col);
            if (res <= deplacement && carte.Cases[lig][col] != carte.Fabrique.Eau)
                return res;
            else
                return -1;
        }

        /// <summary>
        /// find out if an attack is possible
        /// An attack is possible if the target is adjacent and if moving to the position is possible
        /// Obviously, you can't attack your army...
        /// </summary>
        /// <param name="lig"> line of the target </param>
        /// <param name="col"> column of the target </param>
        /// <returns> true if the attack is possible, else false </returns>
        public virtual bool attaquePossible(int lig, int col)
        {
            int distance = Math.Abs(legion.Ligne - lig) + Math.Abs(legion.Colonne - col);
            LegionI leg = carte.getLegion(lig, col);
            if (distance == 1 && leg != null && deplacementPossible(lig, col) != -1)
            {
                if (leg.Unites[0].Joueur != joueur)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// algorithm which decides of the result of a battle
        /// </summary>
        /// <param name="lig"> target line </param>
        /// <param name="col"> target column </param>
        public virtual void attaquer(int lig, int col)
		{
            if (attaquePossible(lig, col))
            {
                Random rand = new Random();

                //the defensor is the units which have the best defense in the targetted legion
                UniteI defenseur = carte.getLegion(lig, col).getBestDefensor();

                //nb : number of "rounds" for this battle
                //randomly chosen between 3 and (max HP of the two battling units + 2)
                double bmax = Math.Max(vie, defenseur.Vie + 2.0);
                int nb = rand.Next(3, (int)bmax);
                int i = 0;

                //the units fight until nb is reached or a unit dies
                while (i < nb && vie > 0 && defenseur.Vie > 0)
                {
                    //probability for the attacking one to loose 1HP
                    double proba = 0.5 + (1.0 - attaque / defenseur.Defense) / 2;

                    Random r = new Random();
                    double de = r.NextDouble();
                    if (de < proba)
                        Vie--;
                    else
                        defenseur.Vie--;
                    i++;
                }

                //if the attacking unit is the winner and if the targetted case is now empty, it moves to the case
                if (vie > 0 && carte.getLegion(lig, col) == null)
                    deplacer(lig, col);
            }
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
            List<List<CaseI>> cases = carte.Cases;
            return cases[legion.Ligne][legion.Colonne].Points;
        }

        /// <summary>
        /// removes this unit of the map
        /// </summary>
        public virtual void removeOfMap()
        {
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
            else if(!legion.Unites.Contains(this))
            {
                legion.Unites.Add(this);
            }
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

        /// <summary>
        /// define rules of bonus and malus
        /// </summary>
        /// <param name="on"> activated or not </param>
        public abstract void setBonusMalusPoints(bool on);

        /// <summary>
        /// suggested cases
        /// </summary>
        public abstract void suggerer();

	}
}

