using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context.config
{
    public class ApprovalRuleConfiguration : IEntityTypeConfiguration<ApprovalRule>
    {
        public void Configure(EntityTypeBuilder<ApprovalRule> builder)
        {
            // Configuración de la clave primaria
            builder.HasKey(approvalRule => approvalRule.Id);

            // Configuración de propiedades
            builder.Property(approvalRule => approvalRule.MinAmount)
                   .IsRequired();

            builder.Property(approvalRule => approvalRule.MaxAmount)
                   .IsRequired();

            builder.Property(approvalRule => approvalRule.StepOrder)
                   .IsRequired();

            // Relación con Area (opcional)
            builder.HasOne(approvalRule => approvalRule.Area)
                   .WithMany(area => area.ApprovalRules)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con Type (opcional)
            builder.HasOne(approvalRule => approvalRule.Type)
                   .WithMany(type => type.ApprovalRules)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con ApproverRole
            builder.HasOne(approvalRule => approvalRule.ApproverRole)
                   .WithMany(role => role.ApprovalRules)
                   .HasForeignKey(approvalRule => approvalRule.ApproverRoleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed de datos iniciales
            SeedApprovalRules(builder);
        }

        private void SeedApprovalRules(EntityTypeBuilder<ApprovalRule> builder)
        {
            builder.HasData(
                new ApprovalRule { Id = 1, MinAmount = 0, MaxAmount = 100000, Area = null, Type = null, StepOrder = 1, ApproverRoleId = 1 },
                new ApprovalRule { Id = 2, MinAmount = 5000, MaxAmount = 20000, Area = null, Type = null, StepOrder = 2, ApproverRoleId = 2 },
                new ApprovalRule { Id = 3, MinAmount = 0, MaxAmount = 20000, Area = null, Type = null, StepOrder = 1, ApproverRoleId = 2 },
                new ApprovalRule { Id = 4, MinAmount = 20000, MaxAmount = 0, Area = null, Type = null, StepOrder = 3, ApproverRoleId = 3 },
                new ApprovalRule { Id = 5, MinAmount = 5000, MaxAmount = 0, Area = null, Type = null, StepOrder = 2, ApproverRoleId = 2 },
                new ApprovalRule { Id = 6, MinAmount = 0, MaxAmount = 10000, Area = null, Type = null, StepOrder = 1, ApproverRoleId = 1 },
                new ApprovalRule { Id = 7, MinAmount = 0, MaxAmount = 10000, Area = null, Type = null, StepOrder = 1, ApproverRoleId = 4 },
                new ApprovalRule { Id = 8, MinAmount = 10000, MaxAmount = 30000, Area = null, Type = null, StepOrder = 2, ApproverRoleId = 2 },
                new ApprovalRule { Id = 9, MinAmount = 30000, MaxAmount = 0, Area = null, Type = null, StepOrder = 2, ApproverRoleId = 3 },
                new ApprovalRule { Id = 10, MinAmount = 0, MaxAmount = 50000, Area = null, Type = null, StepOrder = 1, ApproverRoleId = 4 }
            );
        }
    }
}
