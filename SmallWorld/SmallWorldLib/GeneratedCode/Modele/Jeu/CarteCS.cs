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
   
	public class CarteCS : CarteI
	{
        private CarteWrapper carteW;

        // hashtable associating IDs to unites
        // CarteWrapper (C++) sees unites as IDs
        // Carte (C#) sees unites as instances of the class Unite
        private Hashtable positUnite;
		public virtual Hashtable PositUnite
		{
            get { return positUnite; }
            set { positUnite = value; }
		}

		private FabriqueCaseI fabrique;
        public FabriqueCaseI Fabrique
		{
            get { return fabrique; }
            set { fabrique = value; }
		}

        /**
         * \fn public Carte(int dim, List(JoueurI) joueurs)
         * \brief "Carte" constructor, placing players. Use CarteWrapper.
         * 
         * the C++ map is initialised.
         * Then, the hashtable is filled and the The current map is associated to each unite
         * 
         * param[in] dim : dimension of the map
         * param[in, out] joueurs : list of the players.
         * 
         */
		public CarteCS(int dim, List<JoueurI> joueurs)
		{
            this.carteW = new CarteWrapper(dim, joueurs[0].nbUnitesJouables());/*
            carteW.placeUnites(0, 4, 0, 0);
            carteW.placeUnites(4, 8, 4, 4);*/
            this.positUnite = new Hashtable();
            int i = 0;
            foreach(JoueurI j in joueurs) {
                foreach(UniteI u in j.unite()) {
                    this.positUnite.Add(i, u);
                    u.Carte = this;
                    i++;
                }
            }
		}

		public virtual void getListeAdjacents(UniteI unite, List<Tuple<int, int>> cases)
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

