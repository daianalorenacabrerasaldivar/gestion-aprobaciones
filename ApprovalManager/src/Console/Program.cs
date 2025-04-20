using Microsoft.Extensions.Configuration;

namespace ApprovalManagerConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            //var builder = new ConfigurationBuilder()
            //  .SetBasePath(Directory.GetCurrentDirectory())
            //  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //IConfiguration configuration2 = builder.Build();



            

            var connectionString = configuration["ConnectionString"];
            Console.Write(connectionString);


            Console.WriteLine("Hello, World!");

        }
    }
}
