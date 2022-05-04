using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("Deposits")]
    public class Payins
    {
        [Key]
        public int Id { get; set; } 
        
        public decimal PayinsDepositAmount { get; set; }  

        public int AccountId { get; set; }  
        public DateTime Payins_date { get; set; }




    }
}
