namespace Domain.Entity
{
    public class ApprovalRule
    {
        public long Id { get; set; }
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int StepOrder { get; set; }
        public int ApproverRoleId { get; set; }
        public ApproverRole ApproverRole { get; set; }
        public virtual  Area? Area { get; set; } = null;
        public virtual ProjectType? Type { get; set; }=null;
    }
}
