using Bank_PBD.Model;
using Bank_PBD.Actions;
using Bank_PBD.Properties;
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
using System.Windows.Shapes;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public AddAccount()
        {
            InitializeComponent();
           
        }

        private void btnNewWindowAddAccount_Click(object sender, RoutedEventArgs e)
        {

            using (var db = new DbBankContext())
            {
                var client = db.Clients.Select(x=>x.Id==Session.ValidatedClient.Id);

                var account = new Account()
                {
                    IBAN_Number = Actions.Validation.GenerateIBAN(db),
                    Name = txtbxAccName.Text,
                    IdClient = Session.ValidatedClient.Id,
                };
                db.Accounts.Add(account);

                db.SaveChanges();

            }
            Session.Reload();
            this.Close();
        }
    }
}
