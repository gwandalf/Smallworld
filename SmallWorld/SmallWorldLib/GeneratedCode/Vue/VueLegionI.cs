﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Jeu;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Windows.Shapes;

namespace SmallWorldLib.GeneratedCode.Vue
{
    public interface VueLegionI : AffichableI, INotifyPropertyChanged
    {
        //reference
        LegionI Legion
        {
            get;
            set;
        }
    }
}
