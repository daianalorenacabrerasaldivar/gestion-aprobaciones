using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Context.config
{
    public class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectType>
    {
        public void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            builder.HasKey(type => type.Id);
            builder.Property(type => type.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                    new ProjectType { Id = 1, Name = "Mejora de Procesos" },
                    new ProjectType { Id = 2, Name = "Innovaci�n y Desarrollo" },
                    new ProjectType { Id = 3, Name = "Infraestructura" },
                    new ProjectType { Id = 4, Name = "Capacitaci�n Interna" }
                    );
        }
    }
}
