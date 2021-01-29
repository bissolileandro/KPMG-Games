using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPMG.Games.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected KPGMGamesContext db;

        public RepositoryBase(KPGMGamesContext kPGMGamesContext)
        {
            db = kPGMGamesContext;
        }
        public void AddGameResult(TEntity obj)
        {
            db.Set<TEntity>().Add(obj);
            db.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }
        public void Dispose()
        {
            
        }
    }
}
