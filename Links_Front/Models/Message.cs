using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Links_Front.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MsgId { get; set; }

        [ForeignKey("Cartao")]
        public int From { get; set; }

        [ForeignKey("Cartao")]
        public int To { get; set; }

        public DateTime SentDate { get; set; }

        public string Content { get; set; }



    }
}
