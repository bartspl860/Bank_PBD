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
        public static Client ValidatedClient { get; private set; }
        public static Account[] Accounts { get; private set; }
        public static DateTime? StartTime { get; private set; }
        public static void Start(int id)
        {
            using(var db = new DbBankContext())
            {
                ValidatedClient = db.Clients.Where(w => w.Id == id).First();                
                if (ValidatedClient == null)
                {
                    End(); return;
                }
                Accounts = db.Accounts.Where(w => w.IdClient == ValidatedClient.Id).ToArray();
                Active = true;
                StartTime = DateTime.Now;
            }
        }
        public static void End()
        {
            ValidatedClient = null;
            Accounts = null;
            StartTime = null;
            Active = false;
        }
    }
}
