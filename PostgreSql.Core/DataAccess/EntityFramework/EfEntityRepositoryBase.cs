using Microsoft.EntityFrameworkCore;
using PostgreSql.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PostgreSql.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                await tContext.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
                tContext.SaveChanges();
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                await Task.Run(() => { tContext.Set<TEntity>().Remove(entity); });
                tContext.SaveChanges();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            using (TContext tContext = new TContext())
            {
                IQueryable<TEntity> querys = tContext.Set<TEntity>();

                if (expression != null)
                    querys = querys.Where(expression);

                return await querys.ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext tContext = new TContext())
            {
                IQueryable<TEntity> query = tContext.Set<TEntity>();

                if (filter != null)
                    query = query.Where(filter);

                return await query.SingleOrDefaultAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (TContext tContext = new TContext())
            {
                await Task.Run(() => { tContext.Set<TEntity>().Update(entity); });
                tContext.SaveChanges();
            }
        }
    }
}
