using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Bank_PBD.Storage;
using Bank_PBD.Model;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Wewnetrzne.xaml
    /// </summary>
    public partial class Wewnetrzne : Page
    {
        private Account SelectedAccount { get; set; }
        public Wewnetrzne()
        {
            InitializeComponent();

            foreach(var account in Session.Accounts)
            {
                lbxAccounts.Items.Add(account);
            }
        }
        private void UpdateBalanceAfterTransaction()
        {
            try
            {
                var sum = Convert.ToDecimal(tbxSum.Text);

                if (SelectedAccount != null)
                {
                    var afterTransaction = SelectedAccount.Balance - sum;

                    if (afterTransaction < 0)
                        lblBalanceAfterTransaction.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    else
                        lblBalanceAfterTransaction.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    lblBalanceAfterTransaction.Content = $"Stan konta po transakcji: {afterTransaction}";
                    
                }                   
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxAccounts.SelectedIndex < 0)
                return;

            SelectedAccount = Session.Accounts[lbxAccounts.SelectedIndex];

            lblSelectedAccount.Content = 
                $"Numer IBAN: {SelectedAccount.IBAN_Number} \n" +
                $"Nazwa: {SelectedAccount.Name} \n" +
                $"Stan Konta: {SelectedAccount.Balance} \n";      

            UpdateBalanceAfterTransaction();
        }

        private void tbxSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBalanceAfterTransaction();                        
        }
    }
}
