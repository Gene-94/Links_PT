using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Links_Auth.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // -> Auto increment contraint
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        [NotNull]
        [Display(Name = "Email")]
        [Remote("IsEmailAvalible", "Account", ErrorMessage = "Email alrewady exists")]
        [RegularExpression(@"^([\w.-]+)@([\w-]+)((.(\w){2,3})+)$", ErrorMessage = "This is not a valid email")]
        public string Email { get; set; }
        [Required]
        [NotNull]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [NotNull]
        [Display(Name = "User Type (A - Admin / M - Manager / C - Client)")]
        public char Role { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastLogin { get; set; }
        [NotNull]
        public bool Active { get; set; }
        [NotNull]
        public int ReferenceId { get; set; }


        /*
         Roles:
        A - Admin -> Manages users and logins

        M - Manager -> Manages clients and sales(when implemented)  -> See how partial views work 
        C - Client -> tem acesso a sua area de cliente

        S - Sales -> (future implementation) creates clients and manages cards

        # No one should have direct ease of acces to Messages but the respective user

        Roles will also serve to indicate in witch database table to look for ReferenceId (-> Client Id / Cloaborator Id)
        The reson for having the referenceId on the user, is because it is the User object that is used to redirect the autenticated client to his respective View.
        Also this prevents managers with acces to the clients peek their clients private password, and therefore gain access to messages and other details, only an andmin has acces toi the users and is able to acces this info.
         */
    }
}
