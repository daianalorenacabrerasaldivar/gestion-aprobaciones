using Domain.Enum;

namespace Domain.Entity
{
    public class ProjectProposal
    {
        public Guid Id { get; set; } = Guid.NewGuid();// PK
        public string Title { get; set; } // varchar(255)
        public string Description { get; set; } // varchar(max)
        public Area Area { get; set; } // FK
        public ProjectType Type { get; set; } // FK
        public decimal EstimatedAmount { get; set; } // decimal
        public int EstimatedDuration { get; set; } // int
        public int Status { get; set; } =(int)StatusEnum.Pending ;
        public ApprovalStatus ApprovalStatus { get; set; } = new ApprovalStatus { Id = (int)StatusEnum.Pending };
        public DateTime CreateAt { get; set; } // datetime
        public User CreateBy { get; set; } // FK

        public virtual ICollection<ProjectApprovalStep> ApprovalSteps { get; set; } = new List<ProjectApprovalStep>();
    }
}
