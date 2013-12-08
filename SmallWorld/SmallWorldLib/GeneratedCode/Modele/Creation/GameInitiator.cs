﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Creation
{
	using Modele.Jeu;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Modele.Jeu;

	/// <remarks>
	/// Singleton
	/// 
	/// </remarks>
	public class GameInitiator : GameInitiatorI
	{
		private virtual MonteurPartieI monteurPartie
		{
			get;
			set;
		}

		private virtual PartieI partie
		{
			get;
			set;
		}

		public virtual FabriqueUniteI fabriqueUnite1
		{
			get;
			set;
		}

		public virtual FabriqueUniteI fabriqueUnite2
		{
			get;
			set;
		}

		private GameInitiator()
		{
		}

        /**
         * \fn public virtual void creerPartie()
         * \brief creation of a party using the builder
         * 
         */
		public virtual void creerPartie()
		{
            monteurPartie.setFabriqueUnite(1, fabriqueUnite1);
            monteurPartie.setFabriqueUnite(2, fabriqueUnite2);
            List<JoueurI> joueurs = monteurPartie.makeJoueurs();
            CarteI carte = monteurPartie.makeCarte(joueurs);
		}

	}
}

