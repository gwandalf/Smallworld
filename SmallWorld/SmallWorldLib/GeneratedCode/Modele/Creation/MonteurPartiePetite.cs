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

	public class MonteurPartiePetite : MonteurPartie
	{
        public FabriqueUniteI FabriqueUnite1
        {
            get;
            set
            {
                fabriqueUnite1 = value;
                fabriqueUnite1.defineNbProducts(6);
            }
        }

        public FabriqueUniteI FabriqueUnite2
        {
            get;
            set
            {
                fabriqueUnite1 = value;
                fabriqueUnite1.defineNbProducts(6);
            }
        }

        /**
         * \fn public override CarteI makeCarte(List<JoueurI> joueurs)
         * \brief only call the constructor of a "CarteI" implementation
         * 
         * The map generated places the players. Its dimension is 10
         * 
         * param[in, out] joueurs : parameters of the constructor of the map
         * 
         */
        public override CarteI makeCarte(List<JoueurI> joueurs)
		{
			return new Carte(10, joueurs);
		}

		public MonteurPartiePetite()
		{
            nbTours = 20;
		}

	}
}

