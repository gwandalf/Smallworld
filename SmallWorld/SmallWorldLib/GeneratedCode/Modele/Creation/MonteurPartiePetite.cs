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
                fabriqueUnite1.setNombre(6);
            }
        }

        public FabriqueUniteI FabriqueUnite2
        {
            get;
            set
            {
                fabriqueUnite1 = value;
                fabriqueUnite1.setNombre(6);
            }
        }

		public override CarteI makeCarte()
		{
			throw new System.NotImplementedException();
		}

		public MonteurPartiePetite()
		{
            nbTours = 20;
		}

	}
}

