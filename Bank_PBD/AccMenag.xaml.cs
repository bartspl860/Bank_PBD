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
    /// Logika interakcji dla klasy AccMenag.xaml
    /// </summary>
    public partial class AccMenag : Page
    {
        public AccMenag()
        {
            InitializeComponent();
            ReloadListBox();
        }

        void ReloadListBox()
        {
            lbxAccountsList.Items.Clear();
            foreach (var item in Session.Accounts)
            {
                lbxAccountsList.Items.Add(item);
            }
        }

        private void btnQuestiomMark_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wybierz z listy konto które chcesz usunąć.\nPAMIĘTAJ konto nie może mieć dostępnych środków");
        }

        private void btnAddAcc_Click(object sender, RoutedEventArgs e)
        {
            var dodaj = new AddAccount();
            dodaj.Show();
            ReloadListBox();
        }

        private void btnDeleteAcc_Click(object sender, RoutedEventArgs e)
        {
            var index = lbxAccountsList.SelectedIndex;
            if (index < 0)
            {
                //MessageBox
                return;
            }
            using (var db = new DbBankContext())
            {
                var sessionAccount = Session.Accounts[index];

                var account = db.Accounts
                    .Where(a => a.Id == sessionAccount.Id)
                    .First();
                
                db.Accounts.Remove(account);

                db.SaveChanges();

                Session.ReloadAccounts();

                ReloadListBox();
            }
        }
    }
}
