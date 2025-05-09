using BackendSiniestro.Interface;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendSiniestro.Repository
{
    public class DapperRepository<T> : IRepository<T> 
    {
        private readonly IDbConnection _connection;
        private readonly string _tableName;

        public DapperRepository(IDbConnection connection, string tableName)
        {
            _connection = connection;
            _tableName = tableName;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string tableName)
        {
            var sql = $"SELECT * FROM {tableName}";
            return await _connection.QueryAsync<T>(sql);
        }

    }
}
