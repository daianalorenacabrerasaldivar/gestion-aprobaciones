using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class ProjectApprovalStepConfiguration : IEntityTypeConfiguration<ProjectApprovalStep>
    {
        public void Configure(EntityTypeBuilder<ProjectApprovalStep> builder)
        {
            // Configuración de la clave primaria
            builder.HasKey(p => p.Id);

            // Configuración de la relación con ProjectProposal (FK)
            builder.HasOne(p => p.ProjectProposal)
                   .WithMany(p => p.ApprovalSteps)
                   .HasForeignKey(p => p.ProjectProposalId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la relación con ApproverUser (FK opcional)
            builder.HasOne(p => p.ApproverUser)
                   .WithMany()
                   .HasForeignKey(p => p.ApproverUserId)
                   .IsRequired(false);

            // Configuración de la relación con ApproverRole (FK)
            builder.HasOne(p => p.ApproverRole)
                   .WithMany(role => role.ProjectApprovalSteps) // Relación con ApprovalRules en ApproverRole
                   .HasForeignKey(p => p.ApproverRoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación con ApprovalStatus (FK)
            builder.HasOne(p => p.ApprovalStatus)
                   .WithMany(s => s.ApprovalSteps)
                   .HasForeignKey(p => p.Status)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configuración de propiedades adicionales
            builder.Property(p => p.StepOrder)
                   .IsRequired();

            builder.Property(p => p.DecisionDate)
                   .IsRequired(false);

            builder.Property(p => p.Observations)
                   .HasMaxLength(500)
                   .IsRequired(false);
        }
    }
}
