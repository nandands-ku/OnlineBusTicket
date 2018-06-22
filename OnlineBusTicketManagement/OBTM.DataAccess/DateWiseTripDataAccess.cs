using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace OBTM.DataAccess
{
    public class DateWiseTripDataAccess : GenericDataAccess<DateWiseTrip> , IDateWiseTripRepository
    {
        public DateWiseTripDataAccess(OBTMDbContext context) : base(context)
        {
        }
        public List<DateWiseTrip> GetDateWiseByTrip(int id, DateTime date)
        {
            var DateWiseTripList= (from T in OBTMDbContext.DateWiseTrips where T.TripBaseId == id && T.Date==date.Date select T).ToList();
            return DateWiseTripList;
        }
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripList = OBTMDbContext.DateWiseTrips.Where(dWTrip => dWTrip.TripBaseId == tripId && dWTrip.IsDeleted!=true).ToList();
            return dateWiseTripList;
        }

        public int SoftDelete(int id)
        {
            DateWiseTrip dateWiseTrip = OBTMDbContext.DateWiseTrips.Find(id);
            dateWiseTrip.IsDeleted = true;
            OBTMDbContext.Entry(dateWiseTrip).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }
    }
}
