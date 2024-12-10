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
    /// Interaction logic for IngatlanokModWindow.xaml
    /// </summary>
    public partial class IngatlanokModWindow : Window
    {
        List<Ingatlan> ingatlanok = IngatlanService.GetAllIngatlans();

        List<Ugyintezo> ugyintezos = UgyintezoService.GetallUgyintezo();
        public IngatlanokModWindow()
        {
            InitializeComponent();
            CmbSelectFeltolt();
            cmbTipus.ItemsSource = MainWindow.tipusok;
            cmbTipus.SelectedIndex = 0;

            foreach (Ugyintezo item in ugyintezos)
            {
                cmbUgyintezo.Items.Add($"{item.Id} : {item.Nev}");
            }
            cmbSelect.SelectedIndex = 0;
        }

        private void CmbSelectFeltolt()
        {
            cmbSelect.Items.Clear();
            foreach (Ingatlan ingatlans in ingatlanok)
            {
                cmbSelect.Items.Add($"{ingatlans.Id} : {ingatlans.Település} : {ingatlans.Cim} : {ingatlans.Tipus} : {ingatlans.Ár}");
            }
        }

        private void Modify(object sender, RoutedEventArgs e)
        {
            int ujAr = 0;
            int ujUgyi = 0;
            if (int.TryParse(tbxAr.Text, out ujAr) && int.TryParse(cmbUgyintezo.Text.Split(':')[0], out ujUgyi)) { }
            Ingatlan ujingatlan = new()
            {
                Id = int.Parse(cmbSelect.SelectedItem.ToString().Split(':')[0]),
                Település = tbxTelepules.Text,
                Cim = tbxcCím.Text,
                Ár = ujAr,
                Tipus = cmbTipus.Text,
                KepNev = tbxKepNev.Text,
                UgyintezoId = ujUgyi
            };
            IngatlanService.Update(ujingatlan);
            MessageBox.Show("Sikeres rögzítés!");
            CmbSelectFeltolt();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //kivalasztott megkeresése
            Ingatlan kivalasztott = ingatlanok.FirstOrDefault(i => i.Id == int.Parse(cmbSelect.SelectedItem.ToString().Split(':')[0]));
            //adatok megjelenítése
            if (kivalasztott != null) {
                tbxTelepules.Text = kivalasztott.Település;
                tbxcCím.Text = kivalasztott.Cim;
                tbxKepNev.Text = kivalasztott.KepNev;
                tbxAr.Text = kivalasztott.Ár.ToString();
                cmbTipus.SelectedItem = MainWindow.tipusok.Contains(kivalasztott.Tipus) ? kivalasztott.Tipus : "ba";
                cmbUgyintezo.SelectedItem = $"{kivalasztott.UgyintezoId} : {ugyintezos.FirstOrDefault(u => u.Id == kivalasztott.UgyintezoId).Nev}";

            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem");
            }
        }
    }
}
