using Application.Interface;
using Domain.Common.OptionResponse;
using Domain.Dto;
using Domain.Entity;
using Domain.Enum;

namespace Application.UsesCases.Command.Create
{
    public class CreateProyect
    {
        private readonly IDataBaseService _dataService;

        public CreateProyect(IDataBaseService dataBase)
        {
            _dataService = dataBase;
        }

        public async Task<Option<string>> CreateProjectWithApprovalFlowAsync(ProjectProposalCommand projectProposal)
        {
            if (projectProposal == null)
            {
                return new Failed<string>("La propuesta de proyecto no puede ser nula.");
            }
            var projectProosalCreate= new ProjectProposal
            {
                Title = projectProposal.Title,
                Description = projectProposal.Description,
                Area = projectProposal.Area,
                Type = projectProposal.Type,
                EstimatedAmount = projectProposal.EstimatedAmount,
                EstimatedDuration = projectProposal.EstimatedDuration,
                CreateBy = projectProposal.CreateBy,
                CreateAt = DateTime.UtcNow
            };
            _dataService.ProjectProposals.Add(projectProosalCreate);
            await _dataService.SaveAsync();

            var applicableRules = _dataService.ApprovalRules.Where(r =>
                                        (r.MinAmount == 0 || projectProposal.EstimatedAmount >= r.MinAmount) &&
                                        (r.MaxAmount == 0 || projectProposal.EstimatedAmount <= r.MaxAmount) &&
                                        (r.Area == null || r.Area == projectProposal.Area) &&
                                        (r.Type == null || r.Type == projectProposal.Type))
                                        .OrderByDescending(rule => rule.Area != null && rule.Type != null)
                                        .ThenBy(rule => rule.StepOrder).ToList();

            if (!applicableRules.Any())
            {
                return new Failed<string>("No se encontraron reglas de aprobación aplicables para este proyecto.");
            }

            // Generar los pasos de aprobación
            var approvalSteps = new List<ProjectApprovalStep>();
            foreach (var rule in applicableRules)
            {
                var step = new ProjectApprovalStep
                {
                    ProjectProposalId = projectProosalCreate.Id,
                    ApproverRoleId = rule.ApproverRoleId,
                    StepOrder = rule.StepOrder,
                    DecisionDate = null,
                    Observations = null
                };
                approvalSteps.Add(step);
            }

            // Guardar los pasos de aprobación en la base de datos
            _dataService.ProjectApprovalSteps.AddRange(approvalSteps);
            await _dataService.SaveAsync();
            return new Success<string>("Proyecto creado con exito");
        }
    }
}
