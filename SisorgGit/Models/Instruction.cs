using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.Models
{
    public class Instruction    {
        public string Command { get; set; }
        public string[] Arguments { get; set; }
        //private DateTime _dateRun { get; set; }  
        
        public Instruction(string command, string[] arguments) {
            Command = command;
            Arguments = arguments;
        }

        
    }
}
