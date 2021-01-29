using KPMG.Games.Domain.Interfaces.Application;
using KPMG.Games.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPMG.Games.Application.Application
{
    public class ApplicationBase<TEntity> : IDisposable, IApplicationBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void AddGameResult(IEnumerable<TEntity> obj)
        {
            foreach (var item in obj)
            {
                _serviceBase.AddGameResult(item);
            }
           
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }
        public void Dispose()
        {
            
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _serviceBase.GetAllAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao consultar os dados: {e.Message}");
            }
        }
    }
}
