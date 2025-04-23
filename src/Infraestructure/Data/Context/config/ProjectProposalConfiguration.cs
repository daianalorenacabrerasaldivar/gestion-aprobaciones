using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context.config
{
    public class ProjectProposalConfiguration : IEntityTypeConfiguration<ProjectProposal>
    {
        public void Configure(EntityTypeBuilder<ProjectProposal> builder)
        {
            // Configuración de la clave primaria
            builder.HasKey(p => p.Id);

            // Configuración de propiedades
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

            // Configuración de relaciones

            // Relación con Area
            builder.HasOne(p => p.Area)
                .WithMany(a => a.ApproverRoles) // Cambiar a la colección correcta si es necesario
                .HasForeignKey("AreaId") // Clave foránea implícita
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con ProjectType
            builder.HasOne(p => p.Type)
                .WithMany(pt => pt.ProjectProposals)
                .HasForeignKey("ProjectTypeId") // Clave foránea implícita
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con CreateBy (User)
            builder.HasOne(p => p.CreateBy)
                .WithMany()
                .HasForeignKey("CreateById") // Clave foránea implícita
                .OnDelete(DeleteBehavior.Restrict);

            // Relación con ApprovalStatus
            builder.HasOne(p => p.ApprovalStatus)
                .WithMany(p => p.ProjectProposals)
                .HasForeignKey("ApprovalStatusId") // Clave foránea implícita
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
