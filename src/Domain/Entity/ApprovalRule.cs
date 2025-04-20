namespace Domain.Entity
{
    public class ApprovalRule
    {
        public long Id { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public Area? Area { get; set; } = null;
        public ProjectType? Type { get; set; }=null;
        public int StepOrder { get; set; }
        public int ApprovalReleId { get; set; }
    }
}
