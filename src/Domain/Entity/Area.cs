namespace Domain.Entity
{
    public class Area
    {
       public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApprovalRule> ApprovalRules { get; set; } = new List<ApprovalRule>();
        public virtual ICollection<ProjectProposal> ApproverRoles { get; set; } = new List<ProjectProposal>();
    }
}