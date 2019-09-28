using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSqlExcecuter.Models
{
    public class FileReaderParam
    {
        public string Root { get; }
        public string RootFolder { get; }
        public string DestinationFolder { get; }

        public FileReaderParam(string root, string rootFolder, string destinationFolder)
        {
            Root = root;
            RootFolder = rootFolder;
            DestinationFolder = destinationFolder;
        }
    }
}
