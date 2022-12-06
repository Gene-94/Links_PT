using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Links_Clients.Models
{
    public class Client_Simplified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; internal set; }
    }
}
