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

	public interface MonteurPartieI 
	{
		JoueurI creerJoueur(List<UniteI> unites);

		CarteI makeCarte(List<JoueurI> joueurs);

		List<JoueurI> makeJoueurs();

        void setFabriqueUnite(int i, FabriqueUniteI fu);

	}
}

