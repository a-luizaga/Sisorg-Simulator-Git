using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisorgGit.Models
{
    public class Commit
    {
        public string IdCommit { get; set; }
        public string MsgCommit { get; set; }
        public DateTime DateCommit { get; set; }
        public string[] FilesCommit { get; set; }

        public Commit(string idCommit, string msgCommit, DateTime dateCommit, string[] filesCommit)
        {
            IdCommit = idCommit;
            MsgCommit = msgCommit;
            DateCommit = dateCommit;
            FilesCommit = filesCommit;
        }

    }

}
