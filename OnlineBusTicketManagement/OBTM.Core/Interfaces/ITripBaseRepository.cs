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
        IEnumerable<TripBase> GetRefinedTrips(int routeId, int busOperatorId);
        int DeleteTrip(int id);
    }
}
