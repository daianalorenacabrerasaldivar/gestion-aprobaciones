using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context.config
{
    public class ProjectProposalConfiguration : IEntityTypeConfiguration<ProjectProposal>
    {
        public void Configure(EntityTypeBuilder<ProjectProposal> builder)
        {
            // Configuraci�n de la clave primaria
            builder.HasKey(p => p.Id);

            // Configuraci�n de propiedades
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Description)
                .IsRequired();

            builder.Property(p => p.EstimatedAmount)
                .IsRequired();

            builder.Property(p => p.EstimatedDuration)
                .IsRequired();

            builder.Property(p => p.CreateAt)
                .IsRequired();

            // Configuraci�n de relaciones

            // Relaci�n con Area
            builder.HasOne(p => p.Area)
                .WithMany(a => a.ApproverRoles) // Cambiar a la colecci�n correcta si es necesario
                .HasForeignKey("AreaId") // Clave for�nea impl�cita
                .OnDelete(DeleteBehavior.Restrict);

            // Relaci�n con ProjectType
            builder.HasOne(p => p.Type)
                .WithMany(pt => pt.ProjectProposals)
                .HasForeignKey("ProjectTypeId") // Clave for�nea impl�cita
                .OnDelete(DeleteBehavior.Restrict);

            // Relaci�n con CreateBy (User)
            builder.HasOne(p => p.CreateBy)
                .WithMany()
                .HasForeignKey("CreateById") // Clave for�nea impl�cita
                .OnDelete(DeleteBehavior.Restrict);

            // Relaci�n con ApprovalStatus
            builder.HasOne(p => p.ApprovalStatus)
                .WithMany(p => p.ProjectProposals)
                .HasForeignKey("ApprovalStatusId") // Clave for�nea impl�cita
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
