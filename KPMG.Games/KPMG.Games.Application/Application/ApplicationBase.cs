using KPMG.Games.Domain.Interfaces.Application;
using KPMG.Games.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPMG.Games.Application.Application
{
    public class ApplicationBase<TEntity> : IDisposable, IApplicationBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        public void AddGameResult(TEntity obj)
        {
            _serviceBase.AddGameResult(obj);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }
        public void Dispose()
        {
            
        }
    }
}
