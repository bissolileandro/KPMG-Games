using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Games.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void AddGameResult(TEntity obj);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
