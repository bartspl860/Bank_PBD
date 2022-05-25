using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank_PBD.Model
{
    [Table("Messages")]
    public class InternalMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public int ClientId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool ClientSend { get; set; }
    }
}
