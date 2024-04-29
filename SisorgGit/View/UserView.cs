using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.View
{
    public class UserView
    {

        public string ReadFromKeyboard()
        {
            string input = Console.ReadLine()!;
            return input ?? string.Empty;
        }
    }
}
