using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context
{
    public class ApprovalRuleConfiguration : IEntityTypeConfiguration<ApprovalRule>
    {

        public void Configure(EntityTypeBuilder<ApprovalRule> builder)
        {
            builder.HasKey(approvalRule => approvalRule.Id);
            builder.Property(approvalRule => approvalRule.MinAmount);
            builder.Property(approvalRule => approvalRule.MaxAmount);
            builder.Property(approvalRule => approvalRule.StepOrder);
            builder.Property(approvalRule => approvalRule.ApprovalReleId);

            builder.HasOne(approvalRule => approvalRule.Area)
                .WithMany()
                .HasForeignKey(approvalRule => approvalRule.Area)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(approvalRule => approvalRule.Type)
                .WithMany()
                .HasForeignKey(approvalRule => approvalRule.Type)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
