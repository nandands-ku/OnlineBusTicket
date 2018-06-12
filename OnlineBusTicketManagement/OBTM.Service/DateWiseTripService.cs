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
        public IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId)
        {
            var dateWiseTripRepository = GetInstance<IDateWiseTripRepository>();
            var result = SafeExecute(() => dateWiseTripRepository.GetDateWiseTrip(tripId));
            return result.Data;
        }
    }
}
