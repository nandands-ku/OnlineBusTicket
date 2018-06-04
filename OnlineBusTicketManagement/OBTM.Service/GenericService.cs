using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using OBTM.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class GenericService<TEntity> : BaseService where TEntity : class
    {

        protected T GetInstance<T>() where T : IGenericRepository<TEntity>
        {
            var repository = Configure.GetInstance<T>();

            return repository;
        }

        public Response<int> Insert(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Insert(entity));
            return result;
        }
        public Response<int> Update(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Update(entity));
            return result;

        }
        public Response<int> Save(TEntity entity)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Save(entity));
            return result;

        }
        public virtual TEntity GetById(object id)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.GetById(id));
            return result.Data;
        }
        public virtual Response<int> Delete(object id)
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.Delete(id));
            return result;

        }
        public virtual List<TEntity> GetAll()
        {
            var repository = GetInstance<IGenericRepository<TEntity>>();
            var result = SafeExecute(() => repository.GetAll());
            return result.Data;
        }
    }
}
