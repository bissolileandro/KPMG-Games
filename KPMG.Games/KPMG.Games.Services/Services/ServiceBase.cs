using System;
using System.Collections.Generic;
using System.Text;
using KPMG.Games.Domain.Interfaces.Repositories;
using KPMG.Games.Domain.Interfaces.Services;
using KPMG.Games.Infra.Data.Repositories;

namespace KPMG.Games.Services.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void AddGameResult(TEntity obj)
        {
            _repository.AddGameResult(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Dispose()
        {
            
        }
    }
}
