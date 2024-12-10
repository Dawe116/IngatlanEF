using IngatlanEF.Models;
using IngatlanEF.Services;
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
            cmbTipus.ItemsSource = MainWindow.tipusok;
            cmbTipus.SelectedIndex = 0;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Ingatlan ujingatlan = new()
            {
                Id = 0,
                Település = tbxTelepules.Text,
                Cim = tbxcCím.Text,
                Ár = int.Parse(tbxAr.Text),
                Tipus = cmbTipus.Text,
                KepNev = tbxKepNev.Text,
                UgyintezoId = int.Parse(cmbUgyintezo.Text)
            };
            IngatlanService.Insert(ujingatlan);
            MessageBox.Show("Sikeres rögzítés!");
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
