﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu
{
	using Modele.Creation;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using SmallWorldLib.GeneratedCode.Vue;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /**
     * \class Gaulois
     * 
     * \brief Represents unites of type "Gaulois"
     * 
     */
	public class Gaulois : Unite
	{
        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\gaulois.gif", UriKind.Relative)));

		public override List<Tuple<int,int>> getChoixCases()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public Gaulois()
         * \brief constructor directly from superclass
         * 
         */
		public Gaulois() : base()
		{
            icon = ICON;
		}

		public override int rapporterPoints()
		{
			throw new System.NotImplementedException();
		}

	}
}

