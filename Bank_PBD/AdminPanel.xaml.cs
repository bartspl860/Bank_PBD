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
                foreach (var el in db.Clients)
                    lbxUsersList.Items.Add(el.ToString());
            }
        }

        private void tbxSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (var db = new DbBankContext())
            {
                if (string.IsNullOrEmpty(tbxSearchBar.Text) == false)
                {
                    lbxUsersList.Items.Clear();
                    foreach (var el in db.Clients)
                    {
                        if (el.ToString().Contains(tbxSearchBar.Text))
                        {
                            lbxUsersList.Items.Add(el.ToString());
                        }
                    }
                }
                else if (tbxSearchBar.Text == "")
                {
                    foreach (var el in db.Clients)
                    {
                        lbxUsersList.Items.Add(el.ToString());
                    }
                }
            }
        }

        private void lbxUsersList_Selected(object sender, RoutedEventArgs e)
        {
            using (var db = new DbBankContext())
            {
                foreach (var el in db.Accounts)
                {
                    lstbxAccounts.Items.Add(el.ToString());
                }
            }
        }
    }
}