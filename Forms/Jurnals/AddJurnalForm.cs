using Forms.Abstract;

namespace Forms.Jurnals
{
    public sealed class AddJurnalForm : FormAbstract
    {
        public Guid GroupId { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }
}
