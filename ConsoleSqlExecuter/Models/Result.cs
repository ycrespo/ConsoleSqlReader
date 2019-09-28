using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlExcecuter.Models
{
    public class Result
    {
        public string Path { get; set; }
        public bool IsValid => !string.IsNullOrEmpty(Path);
    }
}
