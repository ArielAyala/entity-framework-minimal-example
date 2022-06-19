using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity_framework_minimal_example.models
{
    public class TaskModel
    {
        [Key]
        public Guid TaskId { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority TaskPriority { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual CategoryModel Category { get; set; }

        [NotMapped]
        public string Resume { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}