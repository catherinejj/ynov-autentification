using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EntityFramework;

namespace Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Text)
                   .HasMaxLength(1200)
                   .IsRequired();

            builder.HasOne(p => p.User)  // Un Post a un seul User
                   .WithMany(u => u.Posts) // Un User a plusieurs Posts
                   .HasForeignKey(p => p.UserId) // Clé étrangère
                   .OnDelete(DeleteBehavior.Cascade); // Suppression en cascade
        }
    }
}