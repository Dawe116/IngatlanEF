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

namespace IngatlanEF.Windows
{
    /// <summary>
    /// Interaction logic for IngatlanokFelviWindow.xaml
    /// </summary>
    public partial class IngatlanokFelviWindow : Window
    {
        public IngatlanokFelviWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
