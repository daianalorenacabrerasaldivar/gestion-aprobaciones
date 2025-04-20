using Infraestructure.Data.Context;
using Infraestructure.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApprovalManagerConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Configuración de appsettings.json
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            // Configuración del contenedor de dependencias
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Ejemplo de uso del contexto de base de datos
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseService>();
                InitialDataLoading.DataLoading(dbContext);
                Console.WriteLine("El contexto de base de datos se configuró correctamente.");
            }

            Console.WriteLine("Hello, World!");
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Registrar el contexto de base de datos con la cadena de conexión
            services.AddDbContext<DataBaseService>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));

            // Registrar otros servicios si es necesario
            // services.AddTransient<IMiServicio, MiServicio>();
        }
    }
}
