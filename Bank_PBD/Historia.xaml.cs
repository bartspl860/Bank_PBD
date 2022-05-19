using Bank_PBD.Model;
using Bank_PBD.Storage;
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

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Wewnetrzne.xaml
    /// </summary>
    public partial class Historia : Page
    {
        public void DisplayTransactions(int selectedAccountIndex)
        {
            var a = Session.Accounts[selectedAccountIndex];
            using (var db = new DbBankContext())
            {
                var accountTransactions = db.InternalTransactions.
                    Where(tr => tr.IdSender == a.Id || tr.IdReceiver == a.Id).
                    Select(tr => tr);
                var acCl = db.Accounts.Join(db.Clients,
                    ac => ac.IdClient,
                    cl => cl.Id,
                    (ac, cl) => new
                    {
                        ac.Id,
                        cl.Name,
                        cl.Surname
                    });
                var resultTmp = accountTransactions.Join(acCl,
                    at => at.IdSender,
                    accl => accl.Id,
                    (at, accl) => new
                    {
                        at.Title,
                        at.Date,
                        at.Sum,
                        at.IdReceiver,
                        accl.Name,
                        accl.Surname
                    });
                var result = resultTmp.Join(acCl,
                    r1 => r1.IdReceiver,
                    accl => accl.Id,
                    (r1, accl) => new
                    {
                        Title = r1.Title,
                        Date = r1.Date,
                        Sum = r1.Sum,
                        SenderName = r1.Name,
                        SenderSurname = r1.Surname,
                        RecieverName = accl.Name,
                        RecieverSurname = accl.Surname
                    });
                foreach (var r in result)
                {
                    lbxHistory.Items.Add(
                        $"Tytuł: {r.Title}\n" +
                        $"Data: {r.Date}\n" +
                        $"Imię i Nazwisko Adresata: {r.SenderName} {r.SenderSurname}\n" +
                        $"Imię i Nazwisko Odbiorcy: {r.RecieverName} {r.RecieverSurname}\n" +
                        $"Suma: {r.Sum}\n"
                        );
                }
            }
        }
        public Historia(int selectedAccountIndex)
        {
            InitializeComponent();
            DisplayTransactions(selectedAccountIndex);
        }
    }
}
