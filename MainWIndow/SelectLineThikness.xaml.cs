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
    /// Interaction logic for SelectLineThikness.xaml
    /// </summary>
    public partial class SelectLineThikness : Window
    {
        public SelectLineThikness()
        {
            InitializeComponent();
            DataContext = this;
        }
        public int ThicknessLine { get; set;}
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ThicknessLine = int.Parse(tbLineWeight.Text);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
