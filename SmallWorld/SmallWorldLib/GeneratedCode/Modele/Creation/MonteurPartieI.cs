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

    /// <summary>
    /// decides the type of the game (size of the map, number of rounds, ...)
    /// </summary>
	public interface MonteurPartieI 
	{
        //number of rounds
        int NbTours
        {
            get;
            set;
        }

        //unit factories
        List<FabriqueI> FabriquesUnite
        {
            get;
            set;
        }

        /// <summary>
        /// The method produces the map, depending on the selected parameters.
        /// The players must be associated to the produced map.
        /// </summary>
        /// <param name="joueurs"> players of the game </param>
        /// <returns> map of the game </returns>
		CarteCS makeCarte(List<Joueur> joueurs);

        /// <summary>
        /// The method creates the internal representation of each player.
        /// The players are created initilized with the units produced by the factories
        /// </summary>
        /// <returns> players of the game </returns>
		List<Joueur> makeJoueurs();

	}
}

