using System.ComponentModel.DataAnnotations;

namespace entity_framework_minimal_example.models
{
    public class CategoryModel
    {
        //[Key]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}