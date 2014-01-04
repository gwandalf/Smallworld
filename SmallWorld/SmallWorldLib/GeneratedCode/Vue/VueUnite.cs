using System;
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

        public VueUnite(UniteI uRef)
        {
            unite = uRef;
            unite.PropertyChanged += new PropertyChangedEventHandler(update);
        }

        public void mouseLeftButtonDown()
        {
            unite.selectionner();
        }

        public void update(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("th");
        }
    }
}
