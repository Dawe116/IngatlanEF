using IngatlanEF.Models;
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
    /// Interaction logic for UgyintezoFelviWindow.xaml
    /// </summary>
    public partial class UgyintezoFelviWindow : Window
    {
        public UgyintezoFelviWindow()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            List<Ugyintezo> ugyintezos = new List<Ugyintezo>();
            ugyintezos.Add(new Ugyintezo()
            {
                Nev = txbUsername.Text,
                TelefonSzám = txbPhone.Text,
                Email = tbxEmail.Text,
            });


        }
    }
}
