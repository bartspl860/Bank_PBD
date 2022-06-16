using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
