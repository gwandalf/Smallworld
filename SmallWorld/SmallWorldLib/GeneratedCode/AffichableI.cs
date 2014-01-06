using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Input;
using System.ComponentModel;

namespace SmallWorldLib.GeneratedCode
{
    public interface AffichableI : ComposantI
    {
        ImageBrush Image
        {
            get;
            set;
        }

        Rectangle Rectangle
        {
            get;
            set;
        }
    }
}
