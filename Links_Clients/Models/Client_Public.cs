using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Links_Clients.Models
{
    public class Client_Public
    {
        public int? Id { get; internal set; }
        public string Name { get; set; }
        public string? Addr { get; set; }
        public string? Postal { get; set; }
        public string? Local { get; set; }
        [Phone]
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Vat { get; internal set; }
        //public byte[]? Avatar { get; set; }
    }
}
