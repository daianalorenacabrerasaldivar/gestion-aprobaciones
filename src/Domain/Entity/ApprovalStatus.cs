using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ApprovalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProjectProposal> ProjectProposals { get; set; } = new List<ProjectProposal>();
       public virtual ICollection<ProjectApprovalStep> ApprovalSteps { get; set; } = new List<ProjectApprovalStep>();
     
    }
}
