using OBTM.Core.Models;
using OBTM.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OBTM.DataAccess
{
    public class DateWiseTripDataAccess : GenericDataAccess<DateWiseTrip> , IDateWiseTripRepository
    {
        public DateWiseTripDataAccess(OBTMDbContext context) : base(context)
        {
        }
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripList = OBTMDbContext.DateWiseTrips.Where(dWTrip => dWTrip.TripBaseId == tripId).ToList();
            return dateWiseTripList;
        }
    }
}
