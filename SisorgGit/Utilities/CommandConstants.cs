using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.Utilities
{
    public static class CommandConstants
    {
        public const string Add = "add";
        public const string Status = "status";
        public const string Reset = "reset";
        public const string Commit = "commit";
        public const string Push = "push";
        public const string Log = "log";
        public const string Remote = "remote";
        public const string Help = "help";
        public const string Exit = "exit";
        public const string Branch = "branch";
        public const string Checkout = "checkout";
        public const string Cls = "cls";


        public static bool IsAValidCommand(string command)
        {
            // Obtener todos los campos públicos y estáticos de esta clase
            var fields = typeof(CommandConstants).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);

            // Iterar sobre cada campo para obtener su valor y compararlo con el comando dado
            foreach (var field in fields)
            {
                string fieldValue = (field.GetValue(null) as string) ?? "";                

                if (fieldValue == command)
                {
                    return true; 
                }
            }

            return false;
        }

    }
}
