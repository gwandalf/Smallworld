using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu.Unit;
using SmallWorldLib.GeneratedCode.Vue;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Modele.Jeu
{
    public class Legion : LegionI
    {
        //Units of the legion
        private List<UniteI> unites;
        public List<UniteI> Unites
        {
            get { return unites; }
            set { unites = value; }
        }

        //line number of the position of the legion
        private int ligne;
        public int Ligne
        {
            get { return ligne; }
            set { ligne = value; }
        }

        //column number of the position of the legion
        private int colonne;
        public int Colonne
        {
            get { return colonne; }
            set { colonne = value; }
        }

        private ImageBrush icon;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="unite"> unit which creates the legion (and which becomes its first member) </param>
        /// <param name="lig"> line number of the legion on the map </param>
        /// <param name="col"> column number of the legion on the map </param>
        public Legion(UniteI unite, int lig, int col)
        {
            ligne = lig;
            colonne = col;
            unites = new List<UniteI>();
            unites.Add(unite);
            icon = unite.Icon;
        }

        public VueLegionI makeView()
        {
            VueLegionI res = new VueLegion(this);
            res.Image = icon;
            return res;
        }

        public void afficher()
        {
            OnPropertyChanged("Legion");
        }

        public void detruireLegion()
        {
            OnPropertyChanged("DetruireLegion");
        }
    }
}
