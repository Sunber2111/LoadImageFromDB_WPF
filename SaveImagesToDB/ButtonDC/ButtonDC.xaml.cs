using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SaveImagesToDB.ButtonDC
{
    /// <summary>
    /// Interaction logic for ButtonDC.xaml
    /// </summary>
    public partial class ButtonDC : Window
    {
       
        public ButtonDC()
        {
            InitializeComponent();
            ViewModel v = new ViewModel();
            this.DataContext = v;
        }
    }
}
