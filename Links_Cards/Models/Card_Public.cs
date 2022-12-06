using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Links_Cards.Models
{
    public class Card_Public
    {
        public int CardNr { get; internal set; }
        public string? CardAlias { get; set; }
        public float? Credit { get; set; }
        public DateTime ValidUntil { get; internal set; }

    }
}
