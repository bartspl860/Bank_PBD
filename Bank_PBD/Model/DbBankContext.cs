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
            : base(@"Data Source=(localdb)\MSSQLLocalDB;
                    Initial Catalog=Bank;Integrated Security=True;
                    Connect Timeout=30;Encrypt=False;
                    TrustServerCertificate=False;
                    ApplicationIntent=ReadWrite;
                    MultiSubnetFailover=False")
        { }
    }
}
