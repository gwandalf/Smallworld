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
    using Wrapper;
    using SmallWorldLib.GeneratedCode.Vue;

	public interface CarteI
	{
        CarteWrapper CarteW
        {
            get;
        }

        int Dim
        {
            get;
        }

        Dictionary<UniteI, Tuple<int, int>> PositUnite
        {
            get;
            set;
        }

        FabriqueCaseI Fabrique
        {
            get;
            set;
        }

        List<UniteI> UniteSet
        {
            get;
        }

        List<List<CaseI>> Cases
        {
            get;
        }

        UniteI Selected
        {
            get;
            set;
        }

		void getListeAdjacents(UniteI unite, List<Tuple<int, int>> cases);

		void deplacer(UniteI unite, int lig, int col);

		void lancerCombat(UniteI unite, int lig, int col);

		bool verifCaseAttaquable(JoueurI joueur, int lig, int col);

		Unite getDefenseur(int lig, int col);

		bool isEmpty(int lig, int col);

		void addUnite(UniteI unite);

        VueCaseI makeView(int l, int c);

	}
}

