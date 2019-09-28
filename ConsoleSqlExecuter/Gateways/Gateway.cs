using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConsoleSqlExcecuter.Readers;

namespace ConsoleSqlExcecuter.Gateways
{
    public class Gateway
    {
        private readonly IDataReader _reader;
        private readonly IFileReader _fileReader;

        public Gateway(IDataReader reader, IFileReader fileReader)
        {
            _reader = reader;
            _fileReader = fileReader;
        }

        public void Execute()
        {
            var sqlInfos = _fileReader.ReadSql();

            foreach (var sqlInfo in sqlInfos)
            {
                // TODO: Change _reader method.
                var excExecutionTime = _reader.GetExecutionTime(sqlInfo.Content);
                Console.WriteLine(Path.GetFileName(sqlInfo.Path) + "  " + excExecutionTime);
            }
            Console.WriteLine("Press any key to Exit");
            Console.Read();
        }
    }
}
