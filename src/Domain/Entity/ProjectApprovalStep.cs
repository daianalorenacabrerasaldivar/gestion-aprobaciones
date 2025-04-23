using Domain.Enum;

namespace Domain.Entity
{
    public class ProjectApprovalStep
    {
        public long Id { get; set; } // PK
        public Guid ProjectProposalId { get; set; } // FK
        public ProjectProposal ProjectProposal { get; set; } // FK
        public int? ApproverUserId { get; set; } // FK [NULL]
        public User? ApproverUser { get; set; } // FK [NULL]
        public int ApproverRoleId { get; set; } // FK
        public ApproverRole ApproverRole { get; set; } // FK
        public int Status { get; set; } = (int)StatusEnum.Pending ; // FK
        public ApprovalStatus ApprovalStatus { get; set; } = new ApprovalStatus { Id = (int)StatusEnum.Pending }; // FK
        public int StepOrder { get; set; } // int
        public DateTime? DecisionDate { get; set; } // datetime [NULL]
        public string? Observations { get; set; } // varchar(max) [NULL]
    }
}
