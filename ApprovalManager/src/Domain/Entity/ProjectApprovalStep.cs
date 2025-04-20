using System;

namespace Domain.Entity
{
    public class ProjectApprovalStep
    {
        public long Id { get; set; } // PK
        public Guid ProjectProposalId { get; set; } // FK
        public int? ApproverUserId { get; set; } // FK [NULL]
        public int ApproverRoleId { get; set; } // FK
        public int Status { get; set; } // FK
        public int StepOrder { get; set; } // int
        public DateTime? DecisionDate { get; set; } // datetime [NULL]
        public string Observations { get; set; } // varchar(max) [NULL]
    }
}
