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
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using SmallWorldLib.GeneratedCode.Vue;

    /**
     * \class Nain
     * 
     * \brief Represents unites of type "Nain"
     * 
     */
	public class Nain : Unite
	{
        public static override ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"../res/dwarf.png", UriKind.Relative)));

		public override List<Tuple<int,int>> getChoixCases()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public Nain()
         * \brief constructor directly from superclass
         * 
         */
		public Nain() : base()
		{
		}

		public override int rapporterPoints()
		{
			throw new System.NotImplementedException();
		}

	}
}

