using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class DateWiseTripService : GenericService<DateWiseTrip>
    {
        public List<DateWiseTrip> GetDateWiseByTrip(int id, DateTime date)
        {
            var repository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => repository.GetDateWiseByTrip(id, date));
            return result.Data;
        }
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripRepository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => dateWiseTripRepository.GetDateWiseTrip(tripId));
            return result.Data;
        }
        public Response<int> SoftDelete(int id)
        {
            var dateWiseTripRepository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => dateWiseTripRepository.SoftDelete(id));
            return result;
        }

        public bool IsSeatsReducible(int NoOfSeats, int DateWiseTripId)
        {
            var dateWiseTripRepository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => dateWiseTripRepository.IsSeatsReducible(NoOfSeats, DateWiseTripId));
            return result.Data;
        }

        public int GetNumOfNotBookedSeats(int DateWiseTripId)
        {
            var dateWiseTripRepository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => dateWiseTripRepository.GetNumOfNotBookedSeats(DateWiseTripId));
            return result.Data;
        }
    }

}
