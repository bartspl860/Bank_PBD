using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Bank_PBD.Model;

namespace Bank_PBD.Actions
{
    public static class Transaction
    {
        public static bool Make(string accountNumber1, string accountNumber2, decimal sum, string title)
        {
            try
            {
                using (var db = new DbBankContext())
                {
                    var acc1 = db.Accounts.Where(w => w.IBAN_Number == accountNumber1).First();
                    var acc2 = db.Accounts.Where(w => w.IBAN_Number == accountNumber2).First();

                    if (acc1 == null)
                        throw new ArgumentNullException(
                            $"Account 1 does not exists in database");

                    if(acc2 == null)
                        throw new ArgumentNullException(
                            $"Account 2 does not exists in database");

                    if (acc1.Balance - sum < 0)
                        throw new InvalidOperationException(
                            $"Insufficient funds on the account: {acc1.Balance}$");

                    acc1.Balance -= sum;
                    acc2.Balance += sum;

                    var transaction = new InternalTransaction()
                    {
                        IdSender = acc1.Id,
                        IdReceiver = acc2.Id,
                        Sum = sum,
                        Title = title,
                        Date = DateTime.Now
                    };

                    db.InternalTransactions.Add(transaction);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }            
            return true;
        }
    }
}
