using Application.Interface;
using Domain.Entity;

namespace Application.Rules
{
    public class AprobationProject
    {
        private readonly IDataBaseService _context;

        public AprobationProject(IDataBaseService context)
        {
            _context = context;
        }

        public void Aprobation(ProjectProposal project)
        {
            // Validar que exista un proyecto con el ID proporcionado
            var existingProject = _context.ProjectProposals.FirstOrDefault(p => p.Id == project.Id);
            if (existingProject == null)
            {
                throw new Exception($"No se encontró un proyecto con el ID {project.Id}");
            }

            // Actualizar los datos del proyecto existente
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.Area = project.Area;
            existingProject.Type = project.Type;
            existingProject.EstimatedAmount = project.EstimatedAmount;
            existingProject.EstimatedDuration = project.EstimatedDuration;
            existingProject.Status = project.Status;

            var result = _context.SaveAsync();
        }
    }
}
