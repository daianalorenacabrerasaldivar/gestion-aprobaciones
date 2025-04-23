using Application.Interface;
using Domain.Entity;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rules
{
    public class MenuManager
    {
        private readonly IDataBaseService _context;
        public MenuManager(IDataBaseService context)
        {
            _context = context;
        }
        public void MenuProjectProporsal(User user)
        {
            

        }

        public List<ProjectProposal> GetPendingProposalsByUserRole(User user)
        {
            // Obtener las reglas de aprobación que coincidan con el rol del usuario
            var approvalRules = _context.ApprovalRules
                .Where(rule => rule.ApproverRoleId == user.Role)
                .ToList();

            // Filtrar las propuestas de proyecto que cumplan con las reglas y estén en estado "Pending"
            var pendingProposals = _context.ProjectProposals
                .Where(proposal => proposal.Status == (int)StatusEnum.Pending // Estado "Pending"
                    && approvalRules.Any(rule =>
                        (rule.Area == null || rule.Area.Id == proposal.Area.Id) &&
                        (rule.Type == null || rule.Type.Id == proposal.Type.Id) &&
                        rule.MinAmount <= proposal.EstimatedAmount &&
                        (rule.MaxAmount == 0 || proposal.EstimatedAmount <= rule.MaxAmount)))
                .ToList();

            return pendingProposals;
        }

    }
}
