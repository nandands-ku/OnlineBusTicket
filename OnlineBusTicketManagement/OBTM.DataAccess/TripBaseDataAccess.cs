using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class TripBaseDataAccess : GenericDataAccess<TripBase>,ITripBaseRepository
    {
        public TripBaseDataAccess(OBTMDbContext context) : base(context)
        {
        }


        public int DeleteTrip(int id)
        {
            var entity = OBTMDbContext.TripBase.Where(i => i.Id == id).Single();
            entity.IsDeleted = true;
            OBTMDbContext.Entry(entity).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }
    }
}
