using Cody_v2.Repositories.Contexts;
using Cody_v2.Repositories.Entities;
using Cody_v2.Repositories.Generics;
using Cody_v2.Repositories.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cody_v2.Repositories.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal AppDbContext dbContext;
        internal DbSet<T> dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<int> Delete(T entityToDelete)
        {
            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid Id)
        {
            T entityToDelete = await dbSet.FindAsync(Id);
            if(entityToDelete!=null)
                return await this.Delete(entityToDelete);
            else 
                return -1;
        }

        public async Task<int> Delete(string Id)
        {
            T entityToDelete = await dbSet.FindAsync(Id);
            if (entityToDelete != null)
                return await this.Delete(entityToDelete);
            else
                return -1;
        }

        public async Task<int> Delete(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            dbSet.RemoveRange(query);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            return await GetByConditionQueryable(filter, orderBy, includeProperties).ToListAsync();
        }

        public IQueryable<T> GetByConditionQueryable(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split( new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public async Task<T> GetById(Guid Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public async Task<T> GetById(string Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public async Task<PageResult<T>> GetWithPaging(int page, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = GetByConditionQueryable(filter, orderBy, includeProperties);
            var result = new PageResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public async Task<int> Insert(T entity)
        {
            dbSet.Add(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> Insert(List<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> SoftDelete(Guid Id)
        {
            var entity = await this.GetById(Id);
            if (entity != null)
            {
                var baseEntity = entity as BaseEntity;
                if (baseEntity != null)
                {
                    baseEntity.IsDeleted = true;
                    return await Update(entity);
                }
                else return -1;
            }
            else
                return -1;
        }

        public async Task<int> SoftDelete(string Id)
        {
            var entity = await this.GetById(Id);
            if (entity != null)
            {
                var baseEntity = entity as BaseEntity;
                if (baseEntity != null)
                {
                    baseEntity.IsDeleted = true;
                    return await Update(entity);
                }
                else return -1;
            }
            else
                return -1;
        }

        public async Task<int> Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync() ;
        }

        public async Task<int> Update(List<T> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                dbContext.Entry(entity).State = EntityState.Modified;
            }
            return await dbContext.SaveChangesAsync();
        }
    }
}
