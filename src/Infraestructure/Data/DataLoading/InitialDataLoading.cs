using Domain.Entity;
using Infraestructure.Data.Context;

namespace Infraestructure.Data.Seed
{
    public static class InitialDataLoading
    {
        public static void DataLoading(DataBaseService context)
        {
            LoadApprovalRoles(context);
            LoadProjectTypes(context);
            LoadApprovalStatuses(context);
            LoadAreas(context);
            LoadUser(context);
            LoadApprovalRules(context);

        }

        private void LoadApprovalRoles(DataBaseService context)
        {
            if (!context.ApproverRoles.Any())
            {
                context.ApproverRoles.AddRange(
                    new ApproverRole { Id = 1, Name = "Líder de área" },
                    new ApproverRole { Id = 2, Name = "Gerente" },
                    new ApproverRole { Id = 3, Name = "Director" },
                    new ApproverRole { Id = 4, Name = "Comité Técnico" }
                );
                context.SaveChanges();
            }
        }
        private void LoadProjectTypes(DataBaseService context)
        {
            if (!context.ProjectTypes.Any())
            {
                context.ProjectTypes.AddRange(
                    new ProjectType { Id = 1, Name = "Mejora de Procesos" },
                    new ProjectType { Id = 2, Name = "Innovación y Desarrollo" },
                    new ProjectType { Id = 3, Name = "Infraestructura" },
                    new ProjectType { Id = 4, Name = "Capacitación Interna" }
        );
                );
                context.SaveChanges();
            }
        }
        private void LoadApprovalStatuses(DataBaseService context)
        {
            if (!context.ApprovalStatuses.Any())
            {
                context.ApprovalStatuses.AddRange(
                    new ApprovalStatus { Id = 1, Name = "Pending" },
                    new ApprovalStatus { Id = 2, Name = "Approved" },
                    new ApprovalStatus { Id = 3, Name = "Rejected" },
                    new ApprovalStatus { Id = 4, Name = "Observed" }
                );
                context.SaveChanges();
            }
        }
        private void LoadAreas(DataBaseService context)
        {
            if (!context.Areas.Any())
            {
                context.Areas.AddRange(
                    new Area { Id = 1, Name = "Finanzas" },
                    new Area { Id = 2, Name = "Tecnología" },
                    new Area { Id = 3, Name = "Recursos Humanos" },
                    new Area { Id = 4, Name = "Operaciones" }
                );
                context.SaveChanges();
            }
        }
        private void LoadUser(DataBaseService context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Id = 1, Name = "José Ferreyra", Email = "jferreyra@unaj.com", Role = 2 },
                    new User { Id = 2, Name = "Ana Lucero", Email = "alucero@unaj.com", Role = 1 },
                    new User { Id = 3, Name = "Gonzalo Molinas", Email = "gmolinas@unaj.com", Role = 2 },
                    new User { Id = 4, Name = "Lucas Olivera", Email = "lolivera@unaj.com", Role = 3 },
                    new User { Id = 5, Name = "Danilo Fagundez", Email = "dfagundez@unaj.com", Role = 4 },
                    new User { Id = 6, Name = "Gabriel Galli", Email = "ggalli@unaj.com", Role = 4 }
                );
                context.SaveChanges();
            }
        }

        private void LoadApprovalRules(DataBaseService context)
        {
            if (!context.ApprovalRules.Any())
            {
                context.ApprovalRules.AddRange(
                    new ApprovalRule { Id = 1, MinAmount = 0, MaxAmount = 100000, Area = null, Type = null, StepOrder = 1, ApprovalReleId = 1 },
                    new ApprovalRule { Id = 2, MinAmount = 5000, MaxAmount = 20000, Area = null, Type = null, StepOrder = 2, ApprovalReleId = 2 },
                    new ApprovalRule { Id = 3, MinAmount = 0, MaxAmount = 20000, Area = context.Areas.Find(2), Type = context.ProjectTypes.Find(2), StepOrder = 1, ApprovalReleId = 2 },
                    new ApprovalRule { Id = 4, MinAmount = 20000, MaxAmount = 0, Area = null, Type = null, StepOrder = 3, ApprovalReleId = 3 },
                    new ApprovalRule { Id = 5, MinAmount = 5000, MaxAmount = 0, Area = context.Areas.Find(1), Type = context.ProjectTypes.Find(1), StepOrder = 2, ApprovalReleId = 2 },
                    new ApprovalRule { Id = 6, MinAmount = 0, MaxAmount = 10000, Area = null, Type = context.ProjectTypes.Find(2), StepOrder = 1, ApprovalReleId = 1 },
                    new ApprovalRule { Id = 7, MinAmount = 0, MaxAmount = 10000, Area = context.Areas.Find(2), Type = context.ProjectTypes.Find(1), StepOrder = 1, ApprovalReleId = 4 },
                    new ApprovalRule { Id = 8, MinAmount = 10000, MaxAmount = 30000, Area = context.Areas.Find(2), Type = null, StepOrder = 2, ApprovalReleId = 2 },
                    new ApprovalRule { Id = 9, MinAmount = 30000, MaxAmount = 0, Area = context.Areas.Find(3), Type = null, StepOrder = 2, ApprovalReleId = 3 },
                    new ApprovalRule { Id = 10, MinAmount = 0, MaxAmount = 50000, Area = null, Type = context.ProjectTypes.Find(4), StepOrder = 1, ApprovalReleId = 4 }
                );
                context.SaveChanges();
            }
        }


    }
