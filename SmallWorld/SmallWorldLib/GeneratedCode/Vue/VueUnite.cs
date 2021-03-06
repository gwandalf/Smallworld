﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;

namespace SmallWorldLib.GeneratedCode.Vue
{
    /**
     * \class VueUnite
     * \brief view of a unite
     */
    public class VueUnite : VueUniteI
    {

        private UniteI unite;
        public UniteI Unite
        {
            get { return unite; }
        }

        private Border description;
        public Border Description
        {
            get { return description; }
            set { description = value; }
        }
        /*
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }*/

        public VueUnite(UniteI uRef)
        {
            unite = uRef;
            description = new Border();
            //unite.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        public void mouseLeftButtonDown()
        {
            if (unite.Carte.Selected == null || (unite.Carte.Selected != null && unite.Joueur == unite.Carte.Selected.Joueur))
                unite.selectionner();
            else if(unite.Joueur != unite.Carte.Selected.Joueur)
                unite.Carte.Selected.attaquer(unite.Position.Item1, unite.Position.Item2);
        }
        /*
        public void update(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }*/
    }
}
