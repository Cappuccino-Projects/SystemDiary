namespace Models.Tasks
{
    public sealed class TaskStateModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
