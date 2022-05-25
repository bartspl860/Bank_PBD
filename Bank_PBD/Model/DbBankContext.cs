using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    public class DbBankContext : DbContext
    {
        public DbBankContext() 
            : base/*(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=Bank;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False")*/(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Bank; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                      

        { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<InternalTransaction> InternalTransactions { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
