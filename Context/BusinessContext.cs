using BusinessMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessMVC.Context
{
    public class BusinessContext: IdentityDbContext
    {
        public BusinessContext(DbContextOptions<BusinessContext> options): base(options){ }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
