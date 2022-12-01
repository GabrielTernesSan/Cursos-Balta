using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(s => s.Id);
            modelBuilder.Entity<TodoItem>().Property(s => s.User).HasMaxLength(120).HasColumnType("varchar");
            modelBuilder.Entity<TodoItem>().Property(s => s.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(s => s.Done).HasColumnType("bit");
            modelBuilder.Entity<TodoItem>().Property(s => s.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
        }
    }
}
