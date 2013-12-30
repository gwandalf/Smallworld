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
    using Modele.Jeu.Unit;

    /**
     * \class Fabrique<T> where T : Unite, new()
     * \brief generic class used to produce unites of the specified Type
     * 
     */
    /// <remarks>Fabrique</remarks>
    public class Fabrique<T> : FabriqueI where T : UniteI, new()
	{

        protected int nombre;
		public int Nombre
		{
            get { return nombre; }
            set { nombre = value; }
		}

        protected List<UniteI> products;
        public List<UniteI> Products
        {
            get { return products; }
            set { products = value; }
        }

		public virtual void fabriquer()
		{
			products = new List<UniteI>();
            for (int i = 0; i < nombre; i++)
            {
                UniteI u = new T();
                products.Add(u);
                u.Automate = new AutomateUnite(u);
            }
		}

        public void defineNbProducts(int nombre)
        {
            this.Nombre = nombre;
        }

        public int nbProducts()
        {
            return this.Nombre;
        }

        /**
         * \fn List<T> giveProducts()
         * \brief get the list of products
         * 
         */
        public List<UniteI> giveProducts()
        {
            return this.Products;
        }

		public Fabrique()
		{
		}

	}
}

