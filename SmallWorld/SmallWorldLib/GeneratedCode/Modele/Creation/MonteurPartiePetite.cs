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
    /// Builder of a demonstration game : 6 units by army, map of 10 X 10 cases, 20 rounds
    /// </summary>
	public class MonteurPartiePetite : MonteurPartie
	{
        //units factories
        public override List<FabriqueI> FabriquesUnite
        {
            set
            {
                base.FabriquesUnite = value;
                if (value.Count == 2)
                {
                    //we force the number of units to 6
                    foreach (FabriqueI fu in value)
                        fu.Nombre = 6;
                }
            }
        }

        /// <summary>
        /// The method produces the map, depending on the selected parameters.
        /// The players must be associated to the produced map.
        /// The map contains 10 X 10 cases
        /// </summary>
        /// <param name="joueurs"> players of the game </param>
        /// <returns> map of the game </returns>
        public override CarteI makeCarte(List<Joueur> joueurs)
		{
			return new CarteCS(10, joueurs);
		}

        /// <summary>
        /// default constructor
        /// the number of rounds is initilized to 20
        /// </summary>
		public MonteurPartiePetite()
            : base()
		{
            nbTours = 20;
		}

	}
}

