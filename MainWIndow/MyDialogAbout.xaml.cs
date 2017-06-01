using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainWIndow
{
    /// <summary>
    /// Interaction logic for MyDialogAbout.xaml
    /// </summary>

    public partial class MyDialogAbout : Window
    {
        public MyDialogAbout()
        {
            InitializeComponent();
        }
        public MyDialogAbout(MyShapes.MyPolygon myPolygon):this()
        {
            polygonAbout.FillColor = myPolygon.FillColor;
            polygonAbout.BorderColor = myPolygon.BorderColor;
            polygonAbout.PolyThickness = myPolygon.PolyThickness;
        }
    }
}
