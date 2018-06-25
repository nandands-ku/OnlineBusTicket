using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        //public virtual int Delete(object id)
        //{
        //    var obj = OBTMDbSet.Find(id);
        //    OBTMDbSet.Remove(obj);
        //    return OBTMDbContext.SaveChanges();
        //}

        public List<TEntity> GetAll()
        {

            var list = OBTMDbSet.ToList();
            //foreach (var item in list)
            //{
            //    PropertyInfo property = item.GetType().GetProperty("IsDeleted");
            //    var value=property.GetValue(item);
            //    if((bool)value)
            //    {
            //        list.Remove(item);
            //    }
            //}
            return list;
        }

        public TEntity GetById(object id)
        {
            return OBTMDbSet.Find(id);
        }

        public int Save(TEntity entity)
        {
            PropertyInfo property = entity.GetType().GetProperty("CreatedBy");
            property.SetValue(entity, HttpContext.Current.Session["User"], null);
            property = entity.GetType().GetProperty("CreatedOn");
            property.SetValue(entity, DateTime.Now, null);
            OBTMDbSet.Add(entity);
            OBTMDbContext.SaveChanges();
            return OBTMDbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            PropertyInfo property = entity.GetType().GetProperty("UpdatedBy");
            property.SetValue(entity, HttpContext.Current.Session["User"], null);
            property = entity.GetType().GetProperty("UpdatedOn");
            property.SetValue(entity, DateTime.Now, null);
            OBTMDbContext.Entry(entity).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }

        public virtual int Delete(object id)
        {
            var obj = OBTMDbSet.Find(id);
            //Type type = obj.GetType();
            PropertyInfo property = obj.GetType().GetProperty("IsDeleted");
            property.SetValue(obj, true, null);
            return OBTMDbContext.SaveChanges();
        }
    }
}
