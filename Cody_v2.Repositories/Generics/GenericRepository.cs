using Cody_v2.Repositories.Generics;
using Cody_v2.Repositories.Paging;
using System.Linq.Expressions;

namespace Cody_v2.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<int> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetByConditionQueryable(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<PageResult<T>> GetWithPaging(int page, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(List<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
