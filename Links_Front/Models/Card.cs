using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Links_Front.Models
{
    public class Card
    {
        [Key]
        public int CardNr { get; set; }
        [Required]
        public string CardName { get; set; }
        [Required]
        public int ClientId { get; set; } //This is a foreign key       P.S: DataAnnotations are confusing...   bind made in SQL
        public float Credit { get; set; }
        public DateTime ValidUntil { get; set; }

    }
}
