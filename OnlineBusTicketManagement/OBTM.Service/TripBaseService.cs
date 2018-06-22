using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class TripBaseService:GenericService<TripBase>
    {
        public List<TripBase> GetTripByRouteId(int id)
        {
            var repository = GetInstance<ITripBaseRepository>();
            var result = SafeExecute(() => repository.GetTripByRouteId(id));
            return result.Data;
        }
        public List<TripBase> GetTripByRouteIdAndBus(int id, int busOperatorID)
        {
            var repository = GetInstance<ITripBaseRepository>();
            var result = SafeExecute(() => repository.GetTripByRouteIdAndBus(id, busOperatorID));
            return result.Data;
        }
        public IEnumerable<TripBase> GetRefinedTrips(int routeId, int busOperatorId)
        {
            var tripRepository = GetInstance<ITripBaseRepository>();
            var result = SafeExecute(() => tripRepository.GetRefinedTrips(routeId, busOperatorId));
            return result.Data;
        }
        public Response<int> Delete(int id)
        {
            var repository = GetInstance<ITripBaseRepository>();
            var result = SafeExecute(() => repository.Delete(id));
            return result;
        }

    }

}

