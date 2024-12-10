using IngatlanEF.Windows;
using Microsoft.Win32;
using Mysqlx;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IngatlanEF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const string password = "afasztudja";
        public static bool isLogged = false;
        public static string LogName = "";
        public static string[] tipusok = { "családi ház", "lakás", "építési terület", "raktárépület", "nyaraló", "lyuk" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Belepes(object sender, RoutedEventArgs e)
        {
            if (isLogged)
            {
                lblLoggedIn.Content = "Bejelentkezve ";
                isLogged = false;
                mnLogin.Header = "Belépés";
                mnIngatlanok.IsEnabled = false;
                mnUgyintezok.IsEnabled = false;
            }
            else
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (isLogged)
                {
                    mnIngatlanok.IsEnabled = true;
                    mnUgyintezok.IsEnabled = true;
                    lblLoggedIn.Content = $"Bejelentkezve: {LogName}";
                    mnLogin.Header = "Kilépés";
                    mnExport.IsEnabled = true;
                }
            }
        }

        private void IngatlanListazas(object sender, RoutedEventArgs e)
        {
            IngatlanListaWindow ingatlanListaWindow = new IngatlanListaWindow();
            ingatlanListaWindow.ShowDialog();
        }

        private void UgyintezoListazas(object sender, RoutedEventArgs e)
        {
            UgyintezoListaWindow ugyintezoListaWindow = new UgyintezoListaWindow();
            ugyintezoListaWindow.ShowDialog();
        }

        private void UgyintezoFelvi(object sender, RoutedEventArgs e)
        {
            UgyintezoFelviWindow ugyintezofelviwindow = new UgyintezoFelviWindow();
            ugyintezofelviwindow.ShowDialog();
        }

        private void UgyintezoMod(object sender, RoutedEventArgs e)
        {
            UgyintezoModWindow ugyintezoModWindow = new UgyintezoModWindow();
            ugyintezoModWindow.ShowDialog();
        }

        private void UgyintezoDel(object sender, RoutedEventArgs e)
        {
            UgyintezoDelWindow ugyintezoDelWindow = new UgyintezoDelWindow();
            ugyintezoDelWindow.ShowDialog();
        }

        private void IngatlanokFelvi(object sender, RoutedEventArgs e)
        {
            IngatlanokFelviWindow ingatlanokFelviWindow = new IngatlanokFelviWindow();
            ingatlanokFelviWindow.ShowDialog();
        }

        private void IngatlanokMod(object sender, RoutedEventArgs e)
        {
            IngatlanokModWindow ingatlanokModWindow = new IngatlanokModWindow();
            ingatlanokModWindow.ShowDialog();
        }

        private void IngatlanokDel(object sender, RoutedEventArgs e)
        {
            IngatlanokDelWindow ingatlanokDelWindow = new IngatlanokDelWindow();
            ingatlanokDelWindow.ShowDialog();
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                FileName = "export.txt",
                DefaultExt = ".txt",
                Filter = "txt|*.txt"
            };

            if (save.ShowDialog() == true)
            {
                if (File.Exists(save.FileName))
                {
                    MessageBox.Show("A fájl már létezik, felülírja?","Figyelmeztetés",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott állomány");
            }


        }
    }
}