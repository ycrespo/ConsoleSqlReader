using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConsoleSqlExcecuter.Models;

namespace ConsoleSqlExcecuter.FolderManagers
{
    public static class FolderManager
    {

        public static bool TryReadFile(string path, out string content)
        {
            try
            {
                if (!File.Exists(path))
                {
                    content = null;
                    return false;
                }

                content = File.ReadAllText(path);
                return true;
            }
            catch
            {
                content = null;
                return false;
            }
        }

        public static IEnumerable<Result> SearchFolderPaths(string path, string searchedFolderName)
        {
            var directories = Directory.GetDirectories(path);
            var result = new List<Result>();
            foreach (var dir in directories)
            {
                if (dir.Contains(searchedFolderName))
                {
                    result.Add(new Result {Path = dir});
                    continue;
                }
                result.AddRange(SearchFolderPaths(dir, searchedFolderName));
            }
            return result;
        }

        public static bool SearchFile(string path, string searchedFileName)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).FirstOrDefault(f => f.Contains(searchedFileName)) != null;
        }

        public static IEnumerable<string> GetFoldersList(string path)
        {
            return Directory.GetDirectories(path);
        }

        public static IEnumerable<string> GetFileList(string path, string fileExtension = "*")
        {
            return Directory.GetFiles(path, "*." + fileExtension, SearchOption.AllDirectories);
        }

    }
}
