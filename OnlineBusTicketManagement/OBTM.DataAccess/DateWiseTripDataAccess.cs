using OBTM.Core.Models;
using OBTM.Core.Interfaces;

namespace OBTM.DataAccess
{
    public class DateWiseTripDataAccess : GenericDataAccess<DateWiseTrip> , IDateWiseTripRepository
    {
        public DateWiseTripDataAccess(OBTMDbContext context) : base(context)
        {
        }
    }
}
