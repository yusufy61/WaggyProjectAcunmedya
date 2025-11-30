using Microsoft.AspNetCore.Identity;

namespace WaggyProjectAcunmedya.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? ImageUrl { get; set; }
    }
}
