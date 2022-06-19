namespace entity_framework_minimal_example.models
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TaskModel> Tasks { get; set; }
    }
}