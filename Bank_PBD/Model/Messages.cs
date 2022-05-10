using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public int ClientId { get; set; }
        public int WorkerId { get; set; }          
        public DateTime MessageDate { get; set; }

    }
}
