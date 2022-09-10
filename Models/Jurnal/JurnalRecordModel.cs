namespace Models.Jurnal
{
    public sealed class JurnalRecordModel
    {
        public Guid Id { get; set; }
        public Guid MarkId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
