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
    using SmallWorldLib.GeneratedCode;

    /**
     * \class Viking
     * 
     * \brief Represents unites of type "Viking"
     * 
     */
	public class Viking : Unite
	{
        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\res\viking.png", UriKind.Relative)));

		public override List<Tuple<int,int>> getChoixCases()
		{
			throw new System.NotImplementedException();
		}

        /**
         * \fn public Viking()
         * \brief constructor directly from superclass
         * 
         */
		public Viking() : base()
		{
		}

		public override int rapporterPoints()
		{
			throw new System.NotImplementedException();
		}

	}
}

