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
            //legion.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        public void mouseLeftButtonDown()
        {
            
        }

        public void update(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("th");
        }
    }
}
