using System;

namespace Domain.Entity
{
    public class ProjectProposal
    {
        public Guid Id { get; set; } // PK
        public string Title { get; set; } // varchar(255)
        public string Description { get; set; } // varchar(max)
        public Area Area { get; set; } // FK
        public Type Type { get; set; } // FK
        public decimal EstimatedAmount { get; set; } // decimal
        public int EstimatedDuration { get; set; } // int
        public int Status { get; set; } // FK (int)
        public DateTime CreateAt { get; set; } // datetime
        public User CreateBy { get; set; } // FK
    }
}
