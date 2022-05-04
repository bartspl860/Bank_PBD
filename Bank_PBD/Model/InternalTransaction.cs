using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("InternalTransactions")]
    public class InternalTransaction
    {
        [Key]
        public int Id { get; set; }
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
        public decimal Sum { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
