﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Implementation.Modele.Jeu.Unit
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
    using System.Text;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    /**
     * \class Viking
     * 
     * \brief Represents unites of type "Viking"
     * 
     */
    [Serializable]
	public class Viking : Unite
	{
        public static ImageBrush ICON = new ImageBrush(new BitmapImage(new Uri(@"..\..\Resources\viking.png", UriKind.Relative)));

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
            icon = ICON;
		}

        /// <summary>
        /// special rule for vikings : a point is added if there is a case 'sea' besides the actual position
        /// </summary>
        /// <returns> points related to the actual position of the unite on the map </returns>
        public override int rapporterPoints()
        {
            int res = base.rapporterPoints();
            
            //we look for a case of type sea in one of the adjacent cases
            int i = 0;
            bool trouve = false;
            List<Tuple<int,int>> adj = carte.getListeAdjacents(this);
            while (i < adj.Count && !trouve)
            {
                if (carte.Cases[adj[i].Item1][adj[i].Item2] == carte.Fabrique.Eau)
                    trouve = true;
                i++;
            }

            //a point is added if there is a case 'sea' besides the actual position
            if (trouve)
                res++;
            return res;
        }

        public override int deplacementPossible(int lig, int col)
        {
            int res = Math.Abs(legion.Ligne - lig) + Math.Abs(legion.Colonne - col);
            if (res <= deplacement)
                return res;
            else
                return -1;
        }

        public override void setBonusMalusPoints(bool on)
        {
            if (on)
            {
                carte.Fabrique.Desert.Points = 0;
            }
            else
            {
                carte.Fabrique.Desert.setDefault();
            }
        }

        public override void suggerer()
        {
            List<Tuple<int, int>> adj = carte.getListeAdjacents(this);
            for (int i = 0; i < adj.Count; i++)
            {
                if (carte.Cases[adj[i].Item1][adj[i].Item2] == carte.Fabrique.Eau)
                    carte.suggerer(adj[i].Item1, adj[i].Item2);
            }
        }

	}
}

