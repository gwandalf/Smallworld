﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu
{
	using Modele;
	using Modele.Creation;
	using System;
    using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using SmallWorldLib.GeneratedCode.Vue;
    using System.ComponentModel;
    using Modele.Jeu.Unit;

	public interface UniteI : INotifyPropertyChanged
	{
    
        int Vie
        {
            get;
            set;
        }

        int Deplacement
        {
            get;
            set;
        }

        int Attaque
        {
            get;
            set;
        }

        int Defense
        {
            get;
            set;
        }

        JoueurI Joueur
        {
            get;
            set;
        }

        CarteI Carte
        {
            get;
            set;
        }

        AutomateUniteI Automate
        {
            set;
        }

        Boolean Turn
        {
            get;
            set;
        }

        //the position of the unit on the map
        Tuple<int, int> Position
        {
            get;
            set;
        }

		void selectionner();

		void deplacer(int lig, int col);

		void attaquer(int lig, int col);

		List<Tuple<int,int>> getChoixCases();

        /**
         * \fn int deplacementPossible(int lig, int col)
         * \brief determine if the current unite can move to the given position
         * 
         * param[in] lig : line number
         * param[in] col : column number
         * 
         * return : distance between the actual position and the target position, or -1 if the move is not possible 
         */
        int deplacementPossible(int lig, int col);

		void engagement(UniteI defenseur);

		int getNbTours(UniteI defenseur);

		UniteI combat(UniteI defenseur);

		void afficher();

        /// <summary>
        /// the method gives the number of points due to the unit
        /// </summary>
        /// <returns> points related to the actual position of the unite on the map </returns>
		int rapporterPoints();

        void placeOnMap(int x, int y);

        VueUniteI makeView();

        void setBonusMalusPoints(bool on);

        void setBonusMalusDeplacement(bool off);

	}
}

