using Forms.Abstract;

namespace Forms.Jurnal
{
    public sealed class SetJurnalMarkForm : FormAbstract
    {
        public Guid PublicUserId { get; set; }
        public Guid PublicEducatorId { get; set; }
        public Guid MarkId { get; set; }
        public Guid DeciplineId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
