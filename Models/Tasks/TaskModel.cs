namespace Models.Tasks
{
    public sealed class TaskModel
    {
        public Guid Id { get; set; }
        public TaskStateModel? State { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
