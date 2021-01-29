using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Games.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void AddGameResult(TEntity obj);
        IEnumerable<TEntity> GetAll();
    }
}
