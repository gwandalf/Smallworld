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
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Vue.Jeu;

	public interface CarteI  : Sujet
	{
		void getListeAdjacents(UniteI unite, List<Entry<int listeCases, object int>>);

		void deplacer(UniteI unite, int lig, int col);

		void lancerCombat(UniteI unite, int lig, int col);

		bool verifCaseAttaquable(JoueurI joueur, int lig, int col);

		Unite getDefenseur(int lig, int col);

		bool isEmpty(int lig, int col);

		void addUnite(UniteI unite);

	}
}

