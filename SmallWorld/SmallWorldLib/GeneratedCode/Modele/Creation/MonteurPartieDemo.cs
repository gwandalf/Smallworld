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

	public class MonteurPartieDemo : MonteurPartie
	{

        public override List<FabriqueI> FabriquesUnite
        {
            set
            {
                base.FabriquesUnite = value;
                if (value.Count == 2)
                {
                    foreach (FabriqueI fu in value)
                        fu.Nombre = 4;
                }
            }
        }

        /**
         * \fn public override CarteI makeCarte(List(JoueurI) joueurs)
         * \brief only call the constructor of a "CarteI" implementation
         * 
         * The map generated places the players. Its dimension is 5
         * 
         * param[in, out] joueurs : parameters of the constructor of the map
         * 
         */
		public override Modele.Jeu.CarteI makeCarte(List<JoueurI> joueurs)
		{
            return new CarteCS(5, joueurs);
		}

		public MonteurPartieDemo()
		{
            nbTours = 5;
		}

	}
}

