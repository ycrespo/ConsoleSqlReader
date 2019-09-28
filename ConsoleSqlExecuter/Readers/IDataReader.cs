using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleSqlExcecuter.Readers
{
    public interface IDataReader
    {
        Task<IEnumerable<T>> GetCollection<T>(string command);
        TimeSpan GetExecutionTime(string command);
    }
}
