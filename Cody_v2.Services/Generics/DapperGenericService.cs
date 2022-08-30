
using Cody_v2.Repositories.Interfaces;
using Cody_v2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cody_v2.Services.Generics
{
    public class DapperGenericService : IDapperGenericService
    {
        public readonly IDapperGenericRepository repository;
        public DapperGenericService(IDapperGenericRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<T>> ExecProcedureDataAsync<T>(string ProcedureName, object parametter = null, IDbTransaction transaction = null)
        {
            return await repository.ExecProcedureDataAsync<T>(ProcedureName, parametter, transaction);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
           return await repository.ExecuteAsync(sql, param, transaction, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await repository.QueryAsync<T>(sql, param, transaction, cancellationToken);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await repository.QueryFirstOrDefaultAsync<T>(sql, param, transaction, cancellationToken);
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await repository.QuerySingleAsync<T>(sql, param, transaction, cancellationToken);   
        }
    }
}
