﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using System.Text;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

	public class Eau : Case
	{
        public Eau()
            : base()
        {
            BitmapImage bmp = new BitmapImage(new Uri(@"..\..\Resources\sea.png", UriKind.Relative));
            image = new ImageBrush();
            image.ImageSource = bmp;
        }

        /// <summary>
        /// set default values of the attributes
        /// </summary>
        public override void setDefault()
        {
            points = 0;
            deplacement = false;
        }
	}
}

