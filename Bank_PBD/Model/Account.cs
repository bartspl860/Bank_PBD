using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int Number { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int IdClient { get; set; } 
    }
}
