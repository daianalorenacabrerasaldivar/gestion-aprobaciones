using Domain.Entity;
using Domain.Enum;

namespace Application.UsesCases.Command.Create
{
    public class ApprovalStepCreate
    {
        public List<ProjectApprovalStep> GenerateApprovalSteps(ProjectProposal projectProposal, List<ApprovalRule> rules)
        {
            if (projectProposal == null)
            {
                throw new ArgumentNullException(nameof(projectProposal), "La propuesta de proyecto no puede ser nula.");
            }

            if (rules == null || !rules.Any())
            {
                throw new ArgumentException("No se proporcionaron reglas de aprobación válidas.", nameof(rules));
            }

            // Ordenar las reglas por StepOrder para garantizar el orden correcto de los pasos
            var orderedRules = rules.OrderBy(rule => rule.StepOrder).ToList();

            // Generar los pasos de aprobación
            var approvalSteps = new List<ProjectApprovalStep>();
            foreach (var rule in orderedRules)
            {
                var step = new ProjectApprovalStep
                {
                    ProjectProposalId = projectProposal.Id, // Relación con la propuesta de proyecto
                    ApproverRoleId = rule.ApproverRoleId, // Rol del aprobador según la regla
                    StepOrder = rule.StepOrder, // Orden del paso
                    Status = (int)StatusEnum.Pending, // Estado inicial "Pending"
                    DecisionDate = null, // Fecha de decisión nula al inicio
                    Observations = null // Observaciones vacías al inicio
                };

                approvalSteps.Add(step);
            }




            return approvalSteps;
        }

    }
}
