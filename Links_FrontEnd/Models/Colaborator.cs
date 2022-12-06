using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;


namespace Trabalho_Final.Models
{
    public class Colaborator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Name { get; set; }
        public string Addr { get; set; }
        public string Phone { get; set; }
        [Required]
        [NotNull]
        public string Email { get; set; }
    }
}
