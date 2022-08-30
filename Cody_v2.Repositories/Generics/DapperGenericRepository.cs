using Cody_v2.Repositories.Interfaces;
using Dapper;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Repositories.Generics
{
    public class DapperGenericRepository : IDapperGenericRepository, IDisposable
    {
        private readonly IDbConnection connection;
        private readonly IAppDbContext context;
        public DapperGenericRepository(IConfiguration configuration, IAppDbContext context)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            this.context = context;
        }

        public async Task<IEnumerable<T>> ExecProcedureDataAsync<T>(string ProcedureName, object parametter = null, IDbTransaction transaction = null)
        {
            return await connection.QueryAsync<T>(ProcedureName, parametter, transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
        public void Dispose()
        {
            connection.Dispose();
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await context.Connection.ExecuteAsync(sql, param, transaction);
        }
 
    //    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    //    {
    //        return (await context.Connection.QueryAsync<T>(sql, param, transaction)).AsList();
    //    }
    //    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    //    {
    //        return await context.Connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    //    }
    //    public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    //    {
    //        return await context.Connection.QuerySingleAsync<T>(sql, param, transaction);
    //    }
    }
}
