namespace Models.News
{
    public sealed class NewsAdditionModel
    {
        public Guid UserPrivateId { get; set; }
        public string? Title { get; set; }
        public string? Context { get; set; }
    }
}
