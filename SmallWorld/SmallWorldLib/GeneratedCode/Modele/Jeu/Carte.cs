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
    using Wrapper;
   
	public class Carte : CarteI
	{
        private CarteWrapper carteW;
        
		private int[][] cases
		{
			get;
			set;
		}

		private int dim
		{
			get;
			set;
		}

		public virtual List<UniteI> positUnite
		{
			get;
			set;
		}

		public virtual FabriqueCaseI fabrique
		{
			get;
			set;
		}

		public Carte(int dim)
		{
            this.carteW = new CarteWrapper(dim);
		}

		public virtual void getListeAdjacents(UniteI unite, List<Tuple<int, int>>)
		{
			throw new System.NotImplementedException();
		}

		public virtual void deplacer(UniteI unite, int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool verifCaseAttaquable(JoueurI joueur, int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual void lancerCombat(UniteI unite, int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual Unite getDefenseur(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isEmpty(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual void addUnite(UniteI unite)
		{
			throw new System.NotImplementedException();
		}

	}
}

