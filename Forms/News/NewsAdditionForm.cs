using Forms.Abstract;

namespace Forms.News
{
    public sealed class NewsAdditionForm : FormAbstract
    {
        public Guid UserPrivateId { get; set; }
        public string? Title { get; set; }
        public string? Context { get; set; }
    }
}
