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
using Bank_PBD.Actions;
using System.Data;
using System.Data.SqlClient;
using Bank_PBD.Model;
using Bank_PBD.Storage;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();

            using (var db = new DbBankContext())
            {
                foreach (var client in db.Clients) { 
                    lbxUsersList.Items.Add(client.ToString());
                    localClients.Add(client);
                }
            }
        }

        private List<Client> localClients = new List<Client>(); 

        private void tbxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new DbBankContext())
            {
                localClients.Clear();
                lbxUsersList.Items.Clear();
                if (tbxSearchBar.Text != String.Empty)
                {
                    foreach (var client in db.Clients)
                    {
                        if (client.ToString().Contains(tbxSearchBar.Text))
                        {
                            lbxUsersList.Items.Add(client.ToString());
                            localClients.Add(client);
                        }
                    }
                }
                else
                {
                    foreach (var client in db.Clients)
                    {
                        lbxUsersList.Items.Add(client.ToString());
                        localClients.Add(client);
                    }
                }
            }
        }

        private void lbxUsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstbxAccounts.Items.Clear();
            using (var db = new DbBankContext())
            {
                if (lbxUsersList.SelectedIndex < 0)
                    return;

                var client = localClients[lbxUsersList.SelectedIndex];
                var accounts = db.Accounts.Where(w => w.IdClient == client.Id);
                foreach(var account in accounts)
                {
                    lstbxAccounts.Items.Add(account.ToString());
                }
            }
        }
    }
}