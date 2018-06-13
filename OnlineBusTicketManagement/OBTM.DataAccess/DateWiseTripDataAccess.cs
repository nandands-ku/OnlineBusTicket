using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace OBTM.DataAccess
{
    public class DateWiseTripDataAccess : GenericDataAccess<DateWiseTrip> , IDateWiseTripRepository
    {
        public DateWiseTripDataAccess(OBTMDbContext context) : base(context)
        {
        }
        public List<DateWiseTrip> GetDateWiseByTrip(int id)
        {
            var DateWiseTripList= (from T in OBTMDbContext.DateWiseTrips where T.TripBaseId == id select T).ToList();
            return DateWiseTripList;
        }
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripList = OBTMDbContext.DateWiseTrips.Where(dWTrip => dWTrip.TripBaseId == tripId).ToList();
            return dateWiseTripList;
        }
    }
}
