using Microsoft.AspNetCore.Identity;

namespace lab2.Models.AuthModels
{
    public class ApplicationUser : IdentityUser
    {
        public string address { get; set; }
    }
}
