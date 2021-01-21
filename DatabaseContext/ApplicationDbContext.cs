using BeckITEjendomsmæglerApplikation.Models;
using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BeckITEjendomsmæglerApplikation.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //Bruges til IdentityUser og Entityframework migrations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
