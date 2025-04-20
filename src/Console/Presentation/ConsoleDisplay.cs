namespace ApprovalManagerConsole.Presentation
{
    public class ConsoleDisplay
    {
        public void ShowWelcomeMessage()
        {
            Console.WriteLine("¡Bienvenido a la aplicación de consola de Approval Manager!");
            Console.WriteLine("===============================================");
            Console.WriteLine("Por favor, selecciona una opción del menú:");


        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Crear un nuevo proyecto");
            Console.WriteLine("2. Aprobar un proyecto");
            Console.WriteLine("3. Ver Mis proyectos");
            Console.WriteLine("3. Ver Todos los proyectos");
            Console.WriteLine("4. Ver proyectos Aprobados");
            Console.WriteLine("5. Ver proyectos Rechazados");
            Console.WriteLine("7. Salir");
        }

        public void ShowCreateProject()
        {
            Console.WriteLine("Crear un nuevo proyecto");
            Console.WriteLine("===============================================");
            Console.WriteLine("Por favor, ingresa una descripción de la propuesta de proyecto:");
            var ProjectDescription = Console.ReadLine();
            Console.WriteLine("Por favor, ingresa el tipo de proyecto:");
            var ProjectType = Console.ReadLine();

            Console.WriteLine("Por favor, ingresa el área responsable:");
            var ProjectArea = Console.ReadLine();

        }

        public void ShowApprovalProject()
        {
            Console.WriteLine("Aprobar un proyecto");
            Console.WriteLine("===============================================");

            Console.WriteLine("Por favor, ingresa el ID del proyecto a aprobar:");
            var ProjectId = Console.ReadLine();
            Console.WriteLine("Por favor, ingresa el ID del aprobador:");
            var ApproverId = Console.ReadLine();
        }

        public void ShowProjectDetails(string nameProject, string projectDescription, string projectType, string projectArea)
        {
            
            Console.WriteLine($" {nameProject}");
            Console.WriteLine("===============================================");
            Console.WriteLine($"Descripción del proyecto: {projectDescription}/n");
            Console.WriteLine($"Tipo de proyecto: {projectType}/n");
            Console.WriteLine($"Área responsable: {projectArea} /n");
        }
    }
}
