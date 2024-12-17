
using Microsoft.EntityFrameworkCore;
using NonProfitBlazorSite.Models;

namespace NonProfitBlazorSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Member> Members { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Invoice> Invoices { get; set; } // Added Invoices table
    }
}
