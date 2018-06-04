using System.Collections.Generic;

namespace OBTM.Core.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
       
        int Update(TEntity entity);
        int Save(TEntity entity);
        TEntity GetById(object id);
        List<TEntity> GetAll();
        int Delete(object id);
    }
}
