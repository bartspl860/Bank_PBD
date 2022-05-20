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
using Bank_PBD.Actions;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Wewnetrzne.xaml
    /// </summary>
    public partial class Wewnetrzne : Page
    {
        private Dictionary<string, bool> conditions = new Dictionary<string, bool>();
        private Account SelectedAccount { get; set; }
        private string SelectedTitle { get; set; }
        private decimal SelectedSum { get; set; }
        private string SelectedIban { get; set; }
        public Wewnetrzne()
        {
            InitializeComponent();

            foreach(var account in Session.Accounts)
            {
                lbxAccounts.Items.Add(account);
            }

            conditions.Add("Account", false);
            conditions.Add("Sum", false);
            conditions.Add("Title", false);
            conditions.Add("IBAN", false);
        }
        private void checkConditions()
        {
            foreach (var condition in conditions) { 
                if (!condition.Value)
                {
                    btnSubmitTransaction.IsEnabled = false;
                    return;
                }                
            }
            btnSubmitTransaction.IsEnabled = true;
        }
        private void UpdateBalanceAfterTransaction()
        {
            try
            {
                var sum = Convert.ToDecimal(tbxSum.Text);
                SelectedSum = sum;

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
                conditions["Sum"] = false;
                checkConditions();
                return;
            }

            conditions["Sum"] = true;

            checkConditions();
        }
        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxAccounts.SelectedIndex < 0)
            {
                conditions["Account"] = false;
                return;
            }
                
            SelectedAccount = Session.Accounts[lbxAccounts.SelectedIndex];

            lblSelectedAccount.Content = 
                $"Numer IBAN: {SelectedAccount.IBAN_Number} \n" +
                $"Nazwa: {SelectedAccount.Name} \n" +
                $"Stan Konta: {SelectedAccount.Balance} \n";

            conditions["Account"] = true;
            UpdateBalanceAfterTransaction();
            checkConditions();
        }

        private void tbxSum_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBalanceAfterTransaction();                        
        }

        private void tbxTitle_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (tbxTitle.Text == string.Empty)
            {
                conditions["Title"] = false;
                checkConditions();
                return;
            }
            conditions["Title"] = true;
            SelectedTitle = tbxTitle.Text;
            checkConditions();
        }

        private void tbxIBAN_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (tbxIBAN.Text == string.Empty)
            {
                conditions["IBAN"] = false;
                checkConditions();
                return;
            }
            conditions["IBAN"] = true;
            SelectedIban = tbxIBAN.Text;
            checkConditions();
        }
        private void btnSubmitTransaction_Click(object sender, RoutedEventArgs e)
        {
            Transaction.Make(SelectedAccount.IBAN_Number, SelectedIban, SelectedSum, SelectedTitle);
            MessageBox.Show("Transakcja zrealizowana pomyślnie.");
            SelectedAccount = null;
            SelectedIban = null;
            SelectedSum = 0;
            SelectedTitle = null;
            tbxIBAN.Text = string.Empty;
            tbxSum.Text = string.Empty;
            tbxTitle.Text = string.Empty;
            checkConditions();
        }
    }
}
