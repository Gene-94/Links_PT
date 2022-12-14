using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Links_Cards.Models
{
    public class Card_Raw
    {
        private int LinksPrefix = 970000000;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [NotMapped]

        public long CardNr { get { return Id + LinksPrefix; } } // id + prefix -> can this be generated by database also ?
        public string? CardAlias { get; set; } // allow client to name their cards, it will be the default name on the messages
        [Required]
        [NotNull]
        public int ClientId { get; set; } // Respresent the client, owner of the card
        public float? Credit { get; set; } 
        public DateTime ValidUntil { get; set; } //valid for 30 days, since last deposit
        public bool Active { get; set; }


    }
}
