using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleSqlExcecuter.Readers
{
    public class DataReader : IDataReader
    {
        private readonly string _connectionString;

        public DataReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetCollection<T>(string command)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                return await conn.QueryAsync<T>(command);
            }
        }

        public TimeSpan GetExecutionTime(string command)
        {
            Stopwatch stopWatch = new Stopwatch();
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;
                stopWatch.Start();
                     conn.Query(command);
                stopWatch.Stop();
                return stopWatch.Elapsed;
            }
        }
    }
}
