using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BlazorApp1.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsList> NewsLists { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
    
        
    

