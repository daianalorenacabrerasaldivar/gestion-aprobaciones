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
    }
}
