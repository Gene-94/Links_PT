using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Links_FrontEnd.Models
{
    public class Message
    {
        public int? Id { get; internal set; }
        [Required]
        public long? SenderNr { get; set; } // Messageid + Links Prefix
        [Required]
        public long receiverNr { get; set; }
        public DateTime? DateSent { get;  set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
