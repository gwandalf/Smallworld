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

	public interface JoueurI 
	{
        int Points
        {
            get;
            set;
        }

        //instances of Unite that are in the current instance of Joueur army
        List<UniteI> Unites
        {
            get;
            set;
        }

        bool Turn
        {
            get;
            set;
        }

		void jouer();

		int nbUnitesJouables();

		void passerMain(JoueurI adversaire);

		bool aVaincu(JoueurI adversaire);

		void fin();

        bool unitesSelectionnables(int lig, int col);

        List<UniteI> unite();
	}
}

