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

	public interface FabriqueI
	{
        //number of units that must be produced
        int Nombre
        {
            get;
            set;
        }

        //produced units
        List<UniteI> Products
        {
            get;
            set;
        }

        /**
         * \fn void fabriquer()
         *`\brief production of the units
         * 
         */
        void fabriquer();
	}
}

