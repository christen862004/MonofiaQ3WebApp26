using Microsoft.AspNetCore.Identity;

namespace MonofiaQ3WebApp26.Models
{
    public class AppliactionUser:IdentityUser
    {
        //empty
        public string? Address { get; set; }
    }
}
