using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                db.Set<TEntity>().Add(obj);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao persistir os dados: {e.Message}");
            }            
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return db.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao consultar os dados: {e.Message}");
            }
        }
        public void Dispose()
        {
            
        }
    }
}
