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
        List<Ugyintezo> ugyintezos = UgyintezoService.GetallUgyintezo();
        public IngatlanokFelviWindow()
        {
            InitializeComponent();
            cmbTipus.ItemsSource = MainWindow.tipusok;
            cmbTipus.SelectedIndex = 0;

            foreach (Ugyintezo item in ugyintezos) {
                cmbUgyintezo.Items.Add($"{item.Id} : {item.Nev}");
            }
            cmbUgyintezo.SelectedIndex = 1;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            int ujAr = 0;
            int ujUgyi = 0;
            if (int.TryParse(tbxAr.Text, out ujAr) && int.TryParse(cmbUgyintezo.Text.Split(':')[0], out ujUgyi)) { }
            Ingatlan ujingatlan = new()
            {
                Id = 0,
                Település = tbxTelepules.Text,
                Cim = tbxcCím.Text,
                Ár = ujAr,
                Tipus = cmbTipus.Text,
                KepNev = tbxKepNev.Text,
                UgyintezoId = ujUgyi
            };
            IngatlanService.Insert(ujingatlan);
            MessageBox.Show("Sikeres rögzítés!");
            tbxAr.Text = "";
            tbxcCím.Text = "";
            tbxKepNev.Text = "";
            tbxTelepules.Text = "";
            cmbTipus.SelectedItem = "ba";
            cmbUgyintezo.Text = "";
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
