using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ApprovalRule> ApprovalRules { get; set; }
        public DbSet<ProjectProposal> ProjectProposals { get; set; }
        public DbSet<ProjectApprovalStep> ProjectApprovalSteps { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ApprovalStatus> ApprovalStatuses { get; set; }
        public DbSet<ApproverRole> ApproverRoles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);

        }
        private static void EntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApprovalRuleConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ApprovalStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public async Task<bool> SaveAsync()
        {
            var nroregistrosModificados = await SaveChangesAsync();
            return nroregistrosModificados > 0;
        }

    }
}
