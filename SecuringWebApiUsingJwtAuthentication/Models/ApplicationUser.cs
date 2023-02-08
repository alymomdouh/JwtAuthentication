using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SecuringWebApiUsingJwtAuthentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        { 
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
