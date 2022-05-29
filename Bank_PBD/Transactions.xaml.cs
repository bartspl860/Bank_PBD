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
using Bank_PBD.Model;
using Bank_PBD.Actions;
using System.Data.SqlClient;
using Bank_PBD.Storage;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Transactions.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        public Transactions()
        {
            InitializeComponent();
            Session.Transactions = this;
            Session.ReloadAccounts();
        }


        private void btnInternalTransfers_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Wewnetrzne();
        }       
        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Sele = new Historia(lbxAccounts.SelectedIndex);
            NavigationService.Navigate(Sele);
        }
        private void btnData_Click(object sender, RoutedEventArgs e)
        {
           Main.Content= new AccountInfoPage();
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

            Session.End();
            var lo = new LoginPage();
            NavigationService.Navigate(lo);
        }
        private void btnAccMenag_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AccMenag();
        }

        private void btnOpenChat_Click(object sender, RoutedEventArgs e)
        {
            var chat = new Czat();
            chat.ShowDialog();
        }
    }
}
