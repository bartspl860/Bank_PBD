using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("Clients")]
    public class Client : IUser
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(30)]
        public string Surname { get; set; }
        [Required, MaxLength (30)]
        public string Login { get; set; }
        [Required, MaxLength(96)] //sha384 -> 96 znaków
        public string Password { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}\n" +
                $"----------------\n" +
                $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Login: {Login}\n" +
                $"----------------\n";
        }
    }
}
