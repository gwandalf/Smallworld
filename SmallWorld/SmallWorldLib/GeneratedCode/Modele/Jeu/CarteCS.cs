﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil
//     Les modifications apportées à ce fichier seront perdues si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Modele.Jeu
{
	using Modele;
	using Modele.Creation;
	using System;
    using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using Wrapper;
    using SmallWorldLib.GeneratedCode.Vue;
    using System.ComponentModel;
   
	public class CarteCS : CarteI
	{
        private CarteWrapper carteW;
        public CarteWrapper CarteW
        {
            get { return carteW; }
        }

        public int Dim
        {
            get { return carteW.getDim(); }
        }

        // hashtable associating IDs to unites
        // CarteWrapper (C++) sees unites as IDs
        // Carte (C#) sees unites as instances of the class Unite
        private Dictionary<UniteI, Tuple<int,int>> positUnite;
        public Dictionary<UniteI, Tuple<int, int>> PositUnite
		{
            get { return positUnite; }
            set { positUnite = value; }
		}

		private FabriqueCaseI fabrique;
        public FabriqueCaseI Fabrique
		{
            get { return fabrique; }
            set { fabrique = value; }
		}

        private List<UniteI> uniteSet;
        public List<UniteI> UniteSet
        {
            get { return uniteSet; }
        }

        private List<List<CaseI>> cases;
        public List<List<CaseI>> Cases
        {
            get { return cases; }
        }

        private UniteI selected;
        public UniteI Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        //legions placed on the map
        private List<LegionI> legions;
        public List<LegionI> Legions
        {
            get { return legions; }
            set { legions = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /**
         * \fn public Carte(int dim, List(JoueurI) joueurs)
         * \brief "Carte" constructor, placing players. Use CarteWrapper.
         * 
         * the C++ map is initialized.
         * Then, the hashtable is filled and the The current map is associated to each unite
         * Then, the "real" cases are set
         * 
         * param[in] dim : dimension of the map
         * param[in, out] joueurs : list of the players.
         * 
         */
		public CarteCS(int dim, List<JoueurI> joueurs)
		{
            //construction carteWrapper
            this.carteW = new CarteWrapper(dim, joueurs[0].NbMaxUnites);
            legions = new List<LegionI>();
            this.positUnite = new Dictionary<UniteI, Tuple<int, int>>();
            int[] loc = { 0, dim - 1};

            //cases initilization
            fabrique = new FabriqueCase();
            cases = new List<List<CaseI>>(this.Dim);
            for (int j = 0; j < this.Dim; j++)
            {
                cases.Add(new List<CaseI>(this.Dim));
                for (int k = 0; k < this.Dim; k++)
                {
                    switch (carteW.getCases(j, k))
                    {
                        case 0:
                            cases[j].Add(fabrique.Desert);
                            break;
                        case 1:
                            cases[j].Add(fabrique.Eau);
                            break;
                        case 2:
                            cases[j].Add(fabrique.Foret);
                            break;
                        case 3:
                            cases[j].Add(fabrique.Montagne);
                            break;
                        case 4:
                            cases[j].Add(fabrique.Plaine);
                            break;
                        default: break;
                    }
                }
            }

            int i = 0;
            foreach (JoueurI j in joueurs)
            {
                foreach (UniteI u in j.Unites)
                {
                    u.Carte = this;
                    u.setBonusMalusPoints(true);
                    u.placeOnMap(loc[i], loc[i]);
                    u.setBonusMalusPoints(false);
                }
                i++;
            }
            
		}

        void generateCases(int nbTypes) 
        { 
            this.carteW.generateCases(nbTypes); 
        }

        /// <summary>
        /// the method give a list of all the positions which are ajacents to a unit
        /// </summary>
        /// <param name="unite"> unit of which the ajacent cases are to be given </param>
        /// <returns> list of all the adjacents positions </returns>
		public virtual List<Tuple<int, int>> getListeAdjacents(UniteI unite)
		{
            //we define the values to add
            List<Tuple<int, int>> adders = new List<Tuple<int, int>>(4);
            adders.Add(new Tuple<int, int>(1, 0));
            adders.Add(new Tuple<int, int>(0, 1));
            adders.Add(new Tuple<int, int>(-1, 0));
            adders.Add(new Tuple<int, int>(0, -1));

            //we add successively the possible position only if they are not out of the map
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            for (int i = 0; i < adders.Count; i++)
            {
                Tuple<int, int> t = new Tuple<int, int>(unite.Position.Item1 + adders[i].Item1, unite.Position.Item2 + adders[i].Item2);
                if (t.Item1 < Dim && t.Item2 < Dim && t.Item1 >= 0 && t.Item2 >= 0)
                    res.Add(t);
            }
            return res;
		}

		public virtual void deplacer(UniteI unite, int lig, int col)
		{
            //Il y a t-il des vérifications à faire dans la méthode
            unite.deplacer(lig, col);
		}

		public virtual bool verifCaseAttaquable(JoueurI joueur, int lig, int col)
		{
            //on vérifie qu'il y a des unités de l'autre joueur sur la case donnée
            //Pour le joueur qui attaque, il faut vérifier que son unité peut se déplacer ou attaquer?
			throw new System.NotImplementedException();
		}

		public virtual void lancerCombat(UniteI unite, int lig, int col)
		{
            // si c'est une case attaque, alors bataillllle
			throw new System.NotImplementedException();
		}

		public virtual Unite getDefenseur(int lig, int col)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isEmpty(int lig, int col)
		{
            // bon il faut chercher dans le dictionnaire, 
            if (!this.PositUnite.ContainsValue(new Tuple<int, int>(lig, col)))
                return true;
            return false;
		}

		public virtual void addUnite(UniteI unite)
		{
			throw new System.NotImplementedException();
		}

        public VueCaseI makeView(int l, int c)
        {
            return new VueCase(this, l, c);
        }

	}
}

