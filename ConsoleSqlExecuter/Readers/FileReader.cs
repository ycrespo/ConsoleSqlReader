using System;
using System.Collections.Generic;
using System.IO;
using ConsoleSqlExcecuter.FolderManagers;
using ConsoleSqlExcecuter.Models;

namespace ConsoleSqlExcecuter.Readers
{
    using System.Linq;

    public class FileReader : IFileReader
    {
        private readonly string _root;
        private readonly string _rootFolder;
        private readonly string _destinationFolder;

        public FileReader(FileReaderParam @param)
        {
            _root = @param.Root;
            _rootFolder = @param.RootFolder;
            _destinationFolder = @param.DestinationFolder;
        }

        public List<SqlInfo> ReadSql()
        {
            var sqlFileList = new List<SqlInfo>();
            
            if (!FolderManager.SearchFolderPaths(_root, _rootFolder).First().IsValid)
            {
                Console.WriteLine($"The folder {_rootFolder} was not found please try in another root directory.");
                Console.WriteLine("Pres any key to exit");
                Console.ReadLine();
                return sqlFileList;
            }

            var startRoot = Path.Combine(_root, _rootFolder);
            var rootFolderList = FolderManager.GetFoldersList(startRoot);
            
            foreach (var folder in rootFolderList)
            {
                
                if (!folder.Contains(_destinationFolder))
                {
                    var workingFolders = FolderManager.SearchFolderPaths(folder, _destinationFolder).Where(nf => nf.IsValid).Select(nf => nf.Path).ToList();
                    
                    if (!workingFolders.Any())
                    {
                        continue;
                    }
                    
                    foreach (var workingFolder in workingFolders)
                    {
                        sqlFileList.AddRange(GetSqlFiles(workingFolder));
                    }
                }
                else
                {
                    sqlFileList.AddRange( GetSqlFiles(folder));
                }
            }
            
            return sqlFileList;
        }
        
        private static IEnumerable<SqlInfo> GetSqlFiles(string folderPath)
        {
            Console.WriteLine(folderPath);
            var sqlFiles = FolderManager.GetFileList(folderPath, "sql");

            foreach (var sqlFile in sqlFiles)
            {
                FolderManager.TryReadFile(sqlFile, out var sqlFileContent);
                yield return new SqlInfo 
                {
                    Path = sqlFile,
                    Content = sqlFileContent
                };
            }
        }
    }

}
