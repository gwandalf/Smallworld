﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Creation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using Modele.Jeu;
    using Modele.Jeu.Joueur;

	/// <remarks>Monteur</remarks>
	/// <remarks>Stratégie : difficultée de la partie</remarks>
	public abstract class MonteurPartie : MonteurPartieI
	{

        protected int nbTours;
        public int NbTours
        {
            get;
            set;
        }

        protected List<FabriqueI> fabriquesUnite;
        public List<FabriqueI> FabriquesUnite
		{
			get;
            set
            {
                if (value.Count == 2)
                {
                    fabriquesUnite = value;
                }
            }
		}

		public virtual List<JoueurI> makeJoueurs()
		{
			List<JoueurI> res = new List<JoueurI>();
            foreach (FabriqueI fu in fabriquesUnite)
            {
                fu.fabriquer();
                res.Add(new Joueur(fu.giveProducts()));
            }
            return res;
		}

        public void defineFabriqueUnite<T>(List<FabriqueI> fu)
        {
            this.FabriquesUnite = fu;
        }

		public MonteurPartie()
		{
		}

        public abstract CarteI makeCarte(List<JoueurI> joueurs);

	}
}

