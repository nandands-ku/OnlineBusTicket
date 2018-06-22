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
    public class OperatorRouteMapDataAccess : GenericDataAccess<OperatorRouteMap>, IOperatorRouteMapRepository
    {
        public OperatorRouteMapDataAccess(OBTMDbContext context) : base(context)
        {
        }
        public int DeleteOperatorRouteSoft(int id)
        {
            var obj = OBTMDbContext.OperatorRouteMaps.Where(bus => bus.BusOperatorId == id).ToList();
            foreach (var item in obj)
            {
                item.IsDeleted = true;
                OBTMDbContext.Entry(item).State = EntityState.Modified;
            }
            

            
            return OBTMDbContext.SaveChanges();
        }
        public int DeleteSingleRouteForBus(int id)
        {
            var obj = OBTMDbContext.OperatorRouteMaps.Where(opId => opId.Id == id).ToList();
            foreach (var item in obj)
            {
                item.IsDeleted = true;
                OBTMDbContext.Entry(item).State = EntityState.Modified;
            }
            

            return OBTMDbContext.SaveChanges();
        }
    }
}
