using Bank_PBD.Storage;
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

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy AccountInfoPage.xaml
    /// </summary>
    public partial class AccountInfoPage : Page
    {
        public AccountInfoPage()
        {
            InitializeComponent();
            foreach (var account in Session.Accounts)
            {
                lbxAccountSelect.Items.Add(account);
            }
            DisplayAccountInfo(0);
        }
        private void lbxAccountSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayAccountInfo(lbxAccountSelect.SelectedIndex);
        }
        public void DisplayAccountInfo(int acc_index)
        {
            lblAccName.Content = Session.Accounts[acc_index].Name;
            lblAccNR.Content = Session.Accounts[acc_index].IBAN_Number;
            lblAccSaldo.Content = ($"{Session.Accounts[acc_index].Balance}zł");
        }
    }
}
