using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Links_Cards.Models
{
    public class Card_Internal
    {
        public int? Id { get; internal set; }
        public int? CardNr { get; internal set; }
        public string? CardAlias { get; set; } 
        public int  ClientId { get; set; }
        public float? Credit { get; set; }
        public DateTime? ValidUntil { get; internal set; }
        public bool Active { get; set; } = true;
    }
}
