using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        public int Weight { get; set; }

        [JsonIgnore]
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}