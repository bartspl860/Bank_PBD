using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Bank_PBD.Model
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string RequestTitle { get; set; }
        [Required]
        public string RequestContent { get; set; }
        public int AccountId { get; set; }  
        public bool IsRevieved { get; set; }


    }
}
