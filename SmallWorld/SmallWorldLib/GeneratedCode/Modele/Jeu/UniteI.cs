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

	public interface UniteI
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

		void selectionner();

		int verifPointsDeplacement();

		void deplacer(int lig, int col);

		void attaquer(int lig, int col);

		List<Tuple<int,int>> getChoixCases();

		List<Tuple<int,int>> deplacementsPossibles();

		void engagement(UniteI defenseur);

		int getNbTours(UniteI defenseur);

		UniteI combat(UniteI defenseur);

		void afficher();

		int rapporterPoints();

        void defineJoueur(JoueurI joueur);

        void defineCarte(CarteI carte);

	}
}

