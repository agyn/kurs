using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kurs.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Shared.Data.Repos
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected KursContext Context;
        protected DbSet<TEntity> Repo;

        protected BaseRepo(KursContext context)
        {
            Context = context;
            Repo = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression)
        {
            return Repo.Where(expression).AsQueryable();
        }

        public async Task<int> Add(TEntity entity)
        {
//            var first = await Repo.AnyAsync();
//            if (first)
//            {
//                entity.Id = await GetMaxId() + 1;    
//            }
            
            await Repo.AddAsync(entity);
            await Save();
            return entity.Id;
        }

        public async Task AddRange(IEnumerable<TEntity> entity)
        {
            await Repo.AddRangeAsync(entity);
            await Save();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Repo.FindAsync(id);
        }

        public virtual async Task Delete(int id)
        {
            var obj = await GetById(id);
            Repo.Remove(obj);
            await Save();
        }

        public virtual async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            Repo.RemoveRange(entities);
            await Save();
        }

        public async Task Update(TEntity entity)
        {
            Repo.Update(entity);
            Context.Entry(entity).Property(x => x.DateCreate).IsModified = false;
            await Save();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entity)
        {
            Repo.UpdateRange(entity);
            await Save();
        }

        public async Task<int> GetMaxId()
        {
            return await Repo.MaxAsync(x => x.Id);
        }
    }
}