using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class GenericDataAccess<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal OBTMDbContext OBTMDbContext;
        internal DbSet<TEntity> OBTMDbSet;

        public GenericDataAccess(OBTMDbContext context)
        {
            this.OBTMDbContext = context;
            this.OBTMDbSet = context.Set<TEntity>();
        }

        public virtual int Delete(object id)
        {
            var obj = OBTMDbSet.Find(id);
            OBTMDbSet.Remove(obj);
            return OBTMDbContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return OBTMDbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return OBTMDbSet.Find(id);
        }

        public int Save(TEntity entity)
        {
            OBTMDbSet.Add(entity);
            return OBTMDbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            OBTMDbContext.Entry(entity).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }

        //public virtual int Delete(object id)
        //{
        //    var obj = OBTMDbSet.Find(id);
        //    //Type type = obj.GetType();
        //    PropertyInfo property = obj.GetType().GetProperty("IsDeleted");
        //    property.SetValue(obj, Convert.ChangeType(true, property.PropertyType), null);
        //    return OBTMDbContext.SaveChanges();
        //}
    }
}
