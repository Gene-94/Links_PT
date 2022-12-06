using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Links_Clients.Models
{
    public class Client_Raw
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
        public string? Addr { get; set; }
        public string? Postal { get; set; }
        public string? Local { get; set; }
        [Required]
        [NotNull]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [NotNull]
        [EmailAddress]
        public string Email { get; set; }
        public string? Vat { get; set; }
        public bool Active { get; set; } = true;
        //public byte[] Avatar { get; set; }
        
        
    }
}
