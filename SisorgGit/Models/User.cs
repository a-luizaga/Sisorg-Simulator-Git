using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.Models
{
    public class User
    {
        public string Alias { get; set; }
        public List<string> Stage { get; set; }        
        public string CurrentBranch { get; set; }
        public List<string> ListBranchs { get; set; }

        public User(string alias)
        {
            Alias = alias;
            Stage = new List<string>();

            CurrentBranch = "master" + Alias;

            ListBranchs = new List<string> { CurrentBranch };
            
        }
    }
}
