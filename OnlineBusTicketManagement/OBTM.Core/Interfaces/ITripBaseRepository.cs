using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Interfaces
{
    public interface ITripBaseRepository:IGenericRepository<TripBase>
    {
        List<TripBase> GetTripByRouteId(int id);
        List<TripBase> GetTripByRouteIdAndBus(int id, int busOperatorID);
        IEnumerable<TripBase> GetRefinedTrips(int routeId, int busOperatorId);
        //int DeleteTrip(int id);
    }
}
