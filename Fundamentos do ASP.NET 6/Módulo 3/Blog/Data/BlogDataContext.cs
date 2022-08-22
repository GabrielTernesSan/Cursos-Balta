using Blog.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           =>  options.UseSqlServer("Server=localhost,1433;Database=BlogASPNET;User ID=sa;Password=G@abriel613390;TrustServerCertificate=True;");
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.Entity<PostWithTagsCount>(x =>
            {
                x.ToSqlQuery(@"
                                SELECT 
                                   [Title] AS [Name],  
                                   SELECT COUNT([Id]) FROM [Tags] WHERE [PostId] = [Id]
                                        AS [Count]
                                FROM
                                   [Posts]");
            });
        }
    }
}
