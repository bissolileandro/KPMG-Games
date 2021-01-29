using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Games.Domain.Interfaces.Application
{
    public interface IApplicationBase<TEntity> where TEntity : class
    {
        void AddGameResult(IEnumerable<TEntity> obj);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
