using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context.config
{
    public class ApproverRoleConfiguration : IEntityTypeConfiguration<ApproverRole>
    {
        public void Configure(EntityTypeBuilder<ApproverRole> builder)
        {
            builder.HasKey(ar => ar.Id);

           
            builder.Property(ar => ar.Name)
                .IsRequired() 
                .HasMaxLength(25); 

            builder.HasData(
                 new ApproverRole { Id = 1, Name = "L�der de �rea" },
                 new ApproverRole { Id = 2, Name = "Gerente" },
                 new ApproverRole { Id = 3, Name = "Director" },
                 new ApproverRole { Id = 4, Name = "Comit� T�cnico" }
            );
        }
    }
}
