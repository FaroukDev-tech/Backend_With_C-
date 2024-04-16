using BlogAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApi.Data
{
    public class ApiDbContext(DbContextOptions options) : DbContext(options)
    {
        public virtual DbSet<Post> Posts {get; set;}
        public virtual DbSet<Comment> Comments {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>(entity => { 
                entity.HasOne(p => p.Post)
                        .WithMany(c=>c.Comments)
                        .HasForeignKey(p => p.PostId)
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Post_Comment");
            });                        
        }
    }
}