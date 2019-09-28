using System.Collections.Generic;
using ConsoleSqlExcecuter.Models;

namespace ConsoleSqlExcecuter.Readers
{
    public interface IFileReader
    {
        List<SqlInfo> ReadSql();
    }
}
