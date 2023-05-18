using Microsoft.AspNetCore.Identity;
namespace Critical_Flow.Controllers
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}