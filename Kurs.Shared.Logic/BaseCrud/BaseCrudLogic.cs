using Kurs.Shared.Data.Context;
using Kurs.Shared.Data.Repos;
using System;
using System.Threading.Tasks;

namespace Kurs.Shared.Logic
{
    public class BaseCrudLogic<TIRepo, TEntity> : IBaseCrudLogic<TEntity> where TIRepo : IBaseRepo<TEntity> where TEntity : BaseEntity
    {
        protected TIRepo Repo { get; }

        public BaseCrudLogic(TIRepo repo)
        {
            Repo = repo;
        }

        public async Task<int> Add(TEntity entity)
        {
            return await Repo.Add(entity);
        }

        public async Task Delete(int id)
        {
            await Repo.Delete(id);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Repo.GetById(id);
        }

        public async Task Save()
        {
            await Repo.Save();
        }

        public async Task Update(TEntity entity)
        {
            await Repo.Update(entity);
        }
    }
}
