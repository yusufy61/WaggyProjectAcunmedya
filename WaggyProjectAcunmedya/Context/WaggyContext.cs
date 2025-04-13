using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WaggyProjectAcunmedya.Entities;

namespace WaggyProjectAcunmedya.Context
{
    public class WaggyContext : IdentityDbContext<AppUser,AppRole,int> 
    {
        public WaggyContext(DbContextOptions<WaggyContext> opt) : base(opt)
        {            
        }

        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
