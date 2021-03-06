﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Interfaces.Modele.Jeu.Unit
{
	using Implementation.Modele.Jeu.Unit;
    using Interfaces.Vue;
	using System;
    using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using System.ComponentModel;
    using Implementation.Modele.Jeu;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

	public interface UniteI
	{


        ImageBrush Icon
        {
            get;
        }

        double Vie
        {
            get;
            set;
        }

        int Deplacement
        {
            get;
            set;
        }

        double Attaque
        {
            get;
            set;
        }

        double Defense
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

        AutomateUnite Automate
        {
            get;
            set;
        }

        Boolean Turn
        {
            get;
            set;
        }

        //legion of the current unit
        Legion Legion
        {
            get;
            set;
        }

		void selectionner();

		void deplacer(int lig, int col);

		void attaquer(int lig, int col);

		void afficher();

        /// <summary>
        /// the method gives the number of points due to the unit
        /// </summary>
        /// <returns> points related to the actual position of the unite on the map </returns>
		int rapporterPoints();

        void removeOfMap();

        void placeOnMap(int x, int y);

        VueUniteI makeView();

        void setBonusMalusPoints(bool on);

        void suggerer();

	}
}

