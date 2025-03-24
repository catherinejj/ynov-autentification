using Microsoft.EntityFrameworkCore;
using Configurations; // Importer le bon namespace

namespace EntityFramework;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<User> Users { get; set; }

     public DbSet<Post> Posts { get; set; }

     protected override void OnModelCreating(ModelBuilder builder)
     {
         builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
     }
}