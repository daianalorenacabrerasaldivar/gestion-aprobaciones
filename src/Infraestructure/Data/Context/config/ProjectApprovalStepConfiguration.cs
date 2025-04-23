using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configurations
{
    public class ProjectApprovalStepConfiguration : IEntityTypeConfiguration<ProjectApprovalStep>
    {
        public void Configure(EntityTypeBuilder<ProjectApprovalStep> builder)
        {
            // Configuraci�n de la clave primaria
            builder.HasKey(p => p.Id);

            // Configuraci�n de la relaci�n con ProjectProposal (FK)
            builder.HasOne(p => p.ProjectProposal)
                   .WithMany(p => p.ApprovalSteps)
                   .HasForeignKey(p => p.ProjectProposalId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configuraci�n de la relaci�n con ApproverUser (FK opcional)
            builder.HasOne(p => p.ApproverUser)
                   .WithMany()
                   .HasForeignKey(p => p.ApproverUserId)
                   .IsRequired(false);

            // Configuraci�n de la relaci�n con ApproverRole (FK)
            builder.HasOne(p => p.ApproverRole)
                   .WithMany(role => role.ProjectApprovalSteps) // Relaci�n con ApprovalRules en ApproverRole
                   .HasForeignKey(p => p.ApproverRoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configuraci�n de la relaci�n con ApprovalStatus (FK)
            builder.HasOne(p => p.ApprovalStatus)
                   .WithMany(s => s.ApprovalSteps)
                   .HasForeignKey(p => p.Status)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configuraci�n de propiedades adicionales
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
