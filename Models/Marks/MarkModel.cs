namespace Models.Marks
{
    public sealed class MarkModel
    {
        public Guid Id { get; set; }
        public string? Markup { get; set; }
        public int Value { get; set; }
        public string? Description { get; set; }
    }
}
