﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Implementation.Modele.Creation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using Implementation.Modele.Jeu.Unit;
    using Interfaces.Modele.Creation;

    /// <summary>
    /// Factory which produces units of the specified type
    /// </summary>
    /// <typeparam name="T"> T extends Unite -> type of unit to produce </typeparam>
    public class Fabrique<T> : FabriqueI where T : Unite, new()
	{

        //number of units that must be produced
        private int nombre;
		public int Nombre
		{
            get { return nombre; }
            set { nombre = value; }
		}

        //produced units
        private List<Unite> products;
        public List<Unite> Products
        {
            get { return products; }
            set { products = value; }
        }


       /// <summary>
       /// default constructor
       /// </summary>
        public Fabrique()
        {
        }

        /// <summary>
        /// production of the units
        /// </summary>
		public void fabriquer()
		{
			products = new List<Unite>();
            for (int i = 0; i < nombre; i++)
            {
                Unite u = new T();
                products.Add(u);
                u.Automate = new AutomateUnite(u);
            }
		}

	}
}

