﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Modele.Jeu.Unit;
using System.ComponentModel;
using Interfaces.Vue;

namespace Interfaces.Modele.Jeu
{
    public interface LegionI : INotifyPropertyChanged
    {
        //Units of the legion
        List<UniteI> Unites
        {
            get;
            set;
        }

        //line number of the position of the legion
        int Ligne
        {
            get;
            set;
        }

        //column number of the position of the legion
        int Colonne
        {
            get;
            set;
        }

        VueLegionI makeView();

        void afficher();

        void detruireLegion();

        UniteI getBestDefensor();
    }
}
