using Application.Interface;
using Domain.Entity;
using Infraestructure.Data.Configurations;
using Infraestructure.Data.Context.config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        // DbSets para las entidades
        public DbSet<ApprovalRule> ApprovalRules { get; set; }
        public DbSet<ProjectProposal> ProjectProposals { get; set; }
        public DbSet<ProjectApprovalStep> ProjectApprovalSteps { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<ApproverRole> ApproverRoles { get; set; }
        public DbSet<User> Users { get; set; }

        // Constructor que recibe las opciones del contexto
        public DataBaseService(DbContextOptions<DataBaseService> options) : base(options)
        {
        }

        // Configuración del modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        // Configuración de las entidades
        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApprovalRuleConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovalStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ApproverRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectApprovalStepConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectProposalConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        // Método para guardar cambios de forma asíncrona con manejo de excepciones
        public async Task<bool> SaveAsync()
        {
            try
            {
                var nroRegistrosModificados = await SaveChangesAsync();
                return nroRegistrosModificados > 0;
            }
            catch (DbUpdateException ex)
            {
                // Manejo de errores específicos de la base de datos
                Console.WriteLine($"Error al guardar los cambios: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return false;
            }
        }

        // Método para realizar consultas genéricas
        public IQueryable<T> Query<T>() where T : class
        {
            return Set<T>();
        }
    }
}
