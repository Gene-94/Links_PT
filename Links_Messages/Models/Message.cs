using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Links_Messages.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }
        [Required]
        public long SenderNr { get; internal set; } // Messageid + Links Prefix
        [Required]
        public long receiverNr { get; set; }
        public DateTime DateSent { get; internal set; } = DateTime.UtcNow;
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

    }

}
