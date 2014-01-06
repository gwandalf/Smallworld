using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Shapes;
using System.Windows.Input;

namespace SmallWorldLib.GeneratedCode.Vue
{
    public class VueLegion : VueLegionI
    {
        //reference
        private LegionI legion;
        public LegionI Legion
        {
            get { return legion; }
            set { legion = value; }
        }

        private ImageBrush icon;
        public ImageBrush Image
        {
            get { return icon; }
            set { icon = value; }
        }

        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public VueLegion(LegionI lRef)
        {
            legion = lRef;
            legion.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        public void mouseLeftButtonDown()
        {
            //if there is no unit selected, the content of the legion is shown
            if (legion.Unites[0].Carte.Selected == null)
                OnPropertyChanged("Afficher");

            //if there is a selected unit of the same team, the unit is placed in the legion
            else if (legion.Unites[0].Joueur == legion.Unites[0].Carte.Selected.Joueur)
                legion.Unites[0].Carte.deplacer(legion.Unites[0].Carte.Selected, legion.Ligne, legion.Colonne);

            //if the selected unit is not in the same team, the unit attack the legion
            else if (legion.Unites[0].Joueur != legion.Unites[0].Carte.Selected.Joueur)
                legion.Unites[0].Carte.Selected.attaquer(legion.Ligne, legion.Colonne);
        }

        public void update(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}
