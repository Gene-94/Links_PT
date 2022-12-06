using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Links_Clients.Models
{
    public class Client_Internal
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public string? Addr { get; set; }
        public string? Postal { get; set; }
        public string? Local { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Vat { get; set; }
        public bool? Active { get; set; }
    }
}
