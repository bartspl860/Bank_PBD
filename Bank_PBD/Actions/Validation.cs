using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows;
using Bank_PBD.Model;
using Bank_PBD.Storage;
using System.Data.Entity;

namespace Bank_PBD.Actions
{
    public static class Validation
    {
        public enum UserType { CLIENT, EMPLOYEE }
        public async static Task<bool> LoginAsync(string username, string password, UserType userType)
        {
            return await Task.Run(() => Login(username, password, userType));
        }
        public static bool Login(string username, string password, UserType userType)
        {            
            try
            {
                using(var db = new DbBankContext())
                {

                    var hpasswd = Hash(password);
                    IUser user = null; 

                    if(userType == UserType.CLIENT)
                    {
                        user = db.Clients.Where(w => w.Login == username && w.Password == hpasswd).First();
                    }
                    else
                    {
                        user = db.Employees.Where(w => w.Login == username && w.Password == hpasswd).First();
                    }

                    Console.WriteLine(user);

                    if (user == null)
                    {
                        throw new Exception("Login error");
                    }
                        
                    if(userType == UserType.CLIENT)
                        Session.Start(user as Client);
                    else
                        Session.Start(user as Employee);
                }
            }
            catch (Exception ex)
            {                
                return false;
            }
            return true;           
        }

        public static void Logout()
        {
            Session.End();
        }
        public static Task<(bool,string)> RegisterAsync(string login, string password, string name, string surname)
        {
            return Task.Run(() => Register(login, password, name, surname));            
        }
        public static (bool, string) Register(string login, string password, string name, string surname)
        {
            try
            {
                using (var db = new DbBankContext())
                {
                    // Password length check
                    if (password.Length < 8)
                        throw new FormatException("Password must have min 8 characters lenght");

                    // Same login check
                    var sameLoginClients = db.Clients.Where(c => c.Login == login);
                    if (sameLoginClients.Count() != 0)
                        throw new ArgumentException("Client with this login already exists");

                    var client = new Client()
                    {
                        Login = login,
                        Password = Hash(password),
                        Name = name,
                        Surname = surname
                    };
                    db.Clients.Add(client);

                    db.SaveChanges();
                }
                using(var db = new DbBankContext())
                {
                    var client = db.Clients.Select(s => s).OrderByDescending(o => o.Id).First();

                    var account = new Account()
                    {
                        IBAN_Number = GenerateIBAN(db),
                        Name = "Konto osobiste",
                        IdClient = client.Id,
                    };
                    db.Accounts.Add(account);

                    db.SaveChanges();
                    Session.Start(client);
                }
                return (true,"OK");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        private static string Hash(string input)
        {
            var sha384hash = SHA384.Create();
            var sourceBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = sha384hash.ComputeHash(sourceBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
            return hash;
        }
        public static string GenerateIBAN(DbBankContext db)
        {
            const string numbers = "0123456789";
            string result;
            var random = new Random();
            do
            {
                result = "PL";
                result += new string(Enumerable.Repeat(numbers, 32)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
            while (db.Accounts.Where(w => w.IBAN_Number == result).Count() != 0);

            return result;
        }
    }
}
