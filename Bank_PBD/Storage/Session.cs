using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_PBD.Model;

namespace Bank_PBD.Storage
{
    public static class Session
    {
        public static bool Active { get; private set; }
        public static IUser ValidatedUser { get; private set; }
        public static Account[] Accounts { get; private set; }
        public static DateTime? StartTime { get; private set; }
        public static Transactions Transactions { get; set; }
        public static void Start(Client client)
        {
            using(var db = new DbBankContext())
            {                                             
                if (client == null)
                {
                    End(); return;
                }

                ValidatedUser = client;
                Active = true;
                StartTime = DateTime.Now;

                Accounts = db.Accounts.Where(w => w.IdClient == ValidatedUser.Id).ToArray();
            }
        }
        public static void Start(Employee employee)
        {
            if (employee == null)
            {
                End(); return;
            }

            ValidatedUser = employee;
            Active = true;
            StartTime = DateTime.Now;
        }
        public static void End()
        {
            ValidatedUser = null;
            Accounts = null;
            StartTime = null;
            Active = false;
        }
        public static void ReloadAccounts()
        {
            if (ValidatedUser is Employee)
                throw new ArgumentException("Employee doesnt have his own accounts");

            using (var db = new DbBankContext())
            {
                Accounts = db.Accounts.Where(w => w.IdClient == ValidatedUser.Id).ToArray();
            
                Transactions.lbxAccounts.Items.Clear();

                foreach (var account in Session.Accounts)
                {
                    Transactions.lbxAccounts.Items.Add(account);
                }
            }
        }        
    }
}
