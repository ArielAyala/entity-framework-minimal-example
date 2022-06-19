using entity_framework_minimal_example.models;
using Microsoft.EntityFrameworkCore;

namespace entity_framework_minimal_example
{
    public class EfMainContext : DbContext
    {
        public EfMainContext(DbContextOptions options) : base(options) { }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>(category => {
                category.ToTable("Categories");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).HasMaxLength(150).IsRequired();
                category.Property(c => c.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<TaskModel>(task => {
                task.ToTable("Tasks");
                task.HasKey(t => t.TaskId);
                task.HasOne(t => t.Category)
                    .WithMany(c => c.Tasks)
                    .HasForeignKey(t => t.CategoryId);
                task.Property(t => t.Title).HasMaxLength(200).IsRequired();
                task.Property(t => t.Description);
                task.Property(t => t.TaskPriority);
                task.Property(t => t.CreateDate);
                task.Ignore(t => t.Resume);
            });
        }
    }
}