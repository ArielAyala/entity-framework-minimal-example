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
            List<CategoryModel> categoryInit = new List<CategoryModel>();
            categoryInit.Add(new CategoryModel()
            {
                CategoryId = Guid.Parse("1eac6be5-b1c3-459a-a325-058ab197a0fd"),
                Name = "Pending activities",
                Weight = 20
            });
            categoryInit.Add(new CategoryModel()
            {
                CategoryId = Guid.Parse("1eac6be5-b1c3-459a-a325-058ab197a0fc"),
                Name = "Personal activities",
                Weight = 50
            });



            modelBuilder.Entity<CategoryModel>(category =>
            {
                category.ToTable("Categories");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).HasMaxLength(150).IsRequired();
                category.Property(c => c.Description).HasMaxLength(500).IsRequired(false);
                category.Property(c => c.Weight);

                category.HasData(categoryInit);
            });

            List<TaskModel> tasksInit = new List<TaskModel>();
            tasksInit.Add(new TaskModel()
            {
                TaskId = Guid.Parse("508e3246-58ec-423a-b48d-30f9dcd94f9c"),
                CategoryId = Guid.Parse("1eac6be5-b1c3-459a-a325-058ab197a0fd"),
                Title = "Public services payment",
                TaskPriority = Priority.Medium,
                CreateDate = DateTime.Now
            });
            tasksInit.Add(new TaskModel()
            {
                TaskId = Guid.Parse("508e3246-58ec-423a-b48d-30f9dcd94f9d"),
                CategoryId = Guid.Parse("1eac6be5-b1c3-459a-a325-058ab197a0fc"),
                Title = "Check notes",
                TaskPriority = Priority.Low,
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<TaskModel>(task =>
            {
                task.ToTable("Tasks");
                task.HasKey(t => t.TaskId);
                task.HasOne(t => t.Category)
                    .WithMany(c => c.Tasks)
                    .HasForeignKey(t => t.CategoryId);
                task.Property(t => t.Title).HasMaxLength(200).IsRequired();
                task.Property(t => t.Description).IsRequired(false);
                task.Property(t => t.TaskPriority);
                task.Property(t => t.CreateDate);
                task.Ignore(t => t.Resume);

                task.HasData(tasksInit);
            });
        }
    }
}