using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_PBD.Model
{
    [Table("Workers")]
    public class Workers
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(40)]
        public string NameOfWorker { get; set; }
        [Required, MaxLength(40)]
        public string SurnameOfWorker { get; set; }
    }
}
