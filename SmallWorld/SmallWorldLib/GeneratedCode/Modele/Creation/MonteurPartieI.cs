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

	public interface MonteurPartieI 
	{
		JoueurI creerJoueur(List<UniteI> unites);

		CarteI makeCarte();

		List<JoueurI> makeJoueurs(CarteI carte);

        void setFabriqueUnite(int i, FabriqueUniteI fu);

	}
}

