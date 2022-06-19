namespace entity_framework_minimal_example.models
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MyProperty { get; set; }
        public Priority TaskPriority { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}