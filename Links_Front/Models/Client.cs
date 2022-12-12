using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Links_Front.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
        public string Addr { get; set; }
        public string Postal { get; set; }
        public string Local { get; set; }
        public string Phone { get; set; }
        [Required]
        [NotNull]
        [EmailAddress]
        public string Email { get; set; }
        public string Vat { get; set; }

        // public Blob Avatar { get; set; }
    }
}
