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
        public List<TripBase> GetTripByRouteId(int id)
        {
            //var TripBaseList = (from T in OBTMDbContext.TripBases where T.RouteId == id select T).ToList();
            var tripBaseList = OBTMDbContext.TripBases.Where(trip => trip.RouteId == id).ToList();
            return tripBaseList;
        }

        public IEnumerable<TripBase> GetRefinedTrips(int routeId, int busOperatorId)
        {
            var refinedtripList = OBTMDbContext.TripBases.Where(trip => trip.RouteId == routeId && trip.BusOperatorId == busOperatorId).ToList();
            return refinedtripList;
        }


        public int DeleteTrip(int id)
        {
            var entity = OBTMDbContext.TripBases.Where(i => i.Id == id).Single();
            entity.IsDeleted = true;
            OBTMDbContext.Entry(entity).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }
    }
}
