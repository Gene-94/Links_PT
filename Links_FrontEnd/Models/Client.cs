using System.ComponentModel.DataAnnotations;

namespace Trabalho_Final.Models
{
    public class Client
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Addr { get; set; }
        public string? Postal { get; set; }
        public string? Local { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Vat { get; set; }
    }
}
