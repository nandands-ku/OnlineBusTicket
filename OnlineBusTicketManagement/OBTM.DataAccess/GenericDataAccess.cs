using OBTM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class GenericDataAccess<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal OBTMDbContext OBTMDbContext;
        internal DbSet<TEntity> OBTMDbSet;

        internal bool IgnoreTenant;

        public GenericDataAccess(OBTMDbContext context)
        {
            this.OBTMDbContext = context;
            this.OBTMDbSet = context.Set<TEntity>();
        }

        public int Delete(object id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            return OBTMDbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return OBTMDbSet.Find(id);
        }

        public int Insert(TEntity entity)
        {

            OBTMDbSet.Add(entity);
            return OBTMDbContext.SaveChanges();
        }

        public int Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
