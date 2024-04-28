using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.Utilities
{
    public class HelpCommand
    {

        public static void ShowHelp()
        {
            Dictionary<string, (string description, string usage)> commandHelp = new Dictionary<string, (string description, string usage)>
        {
            { "add", ("Agrega archivos al área de preparación.", "add <archivo1> <archivo2> ...") },
            { "reset", ("Quita archivos del área de preparación.", "reset <archivo1> <archivo2> ...") },
            { "commit", ("Crea un nuevo commit con los cambios en el área de preparación.", "commit -m \"<mensaje>\"") },
            { "status", ("Muestra el estado actual del área de preparación.", "status") },
            { "push", ("Envia los commits locales a un servidor remoto", "push") },
            { "log", ("Muestra el registro de commits de la rama actual", "log") },
        };

            Console.WriteLine("Comandos disponibles:");

            foreach (var command in commandHelp)
            {
                Console.WriteLine($"- {command.Key}:");
                Console.WriteLine($"   Descripción: {command.Value.description}");
                Console.WriteLine($"   Uso: {command.Value.usage}\n");
            }
        }


    }
}
