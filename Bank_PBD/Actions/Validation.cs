using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using Bank_PBD.Model;

namespace Bank_PBD.Actions
{
    public static class Validation
    {
        public static bool Login(string username, string password)
        {
            try
            {
                using(var db = new DbBankContext())
                {
                    var sha384hash = SHA384.Create();
                    var sourceBytes = Encoding.UTF8.GetBytes(password);
                    var hashBytes = sha384hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

                    var client = db.Clients.Where(w => w.Login == username && w.Password == hash).First();
                    if (client == null)
                        throw new Exception("Login error");
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
