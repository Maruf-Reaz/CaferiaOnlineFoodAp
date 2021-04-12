
using Microsoft.AspNetCore.Identity;


namespace CaferiaApp.Models.Common.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

        public double Balance { get; set; }
        public byte Status { get; set; }
        
    }
}
