using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Dto
{
    public class ProjectProposalCommand
    {
        public string Title { get; set; } // varchar(255)
        public string Description { get; set; } // varchar(max)
        public Area Area { get; set; } // FK
        public ProjectType Type { get; set; } // FK
        public decimal EstimatedAmount { get; set; } // decimal
        public int EstimatedDuration { get; set; } // int
        public User CreateBy { get; set; } // FK
    }
}
