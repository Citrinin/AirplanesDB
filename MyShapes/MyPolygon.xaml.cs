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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyShapes
{
    /// <summary>
    /// Interaction logic for MyPolygon.xaml
    /// </summary>
    public partial class MyPolygon : UserControl
    {
        public MyPolygon()
        {
            InitializeComponent();
        }
        public MyPolygon(SolidColorBrush fillColor, SolidColorBrush borderColor, int polyThickness) : this()
        {
            this.FillColor = fillColor;
            this.BorderColor = borderColor;
            this.PolyThickness = polyThickness;
        }

        public MyPolygon Clone()
        {
            return new MyPolygon();
        }

        public int PolyThickness
        {
            get { return (int)GetValue(PolyThicknessProperty); }
            set { SetValue(PolyThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PolyThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PolyThicknessProperty =
            DependencyProperty.Register("PolyThickness", typeof(int), typeof(MyPolygon), new PropertyMetadata(1));



        public SolidColorBrush BorderColor
        {
            get { return (SolidColorBrush)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(SolidColorBrush), typeof(MyPolygon), new PropertyMetadata(new SolidColorBrush(Colors.Black)));




        public SolidColorBrush FillColor
        {
            get { return (SolidColorBrush)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor", typeof(SolidColorBrush), typeof(MyPolygon), new PropertyMetadata(new SolidColorBrush(Colors.Yellow)));

    }
}
