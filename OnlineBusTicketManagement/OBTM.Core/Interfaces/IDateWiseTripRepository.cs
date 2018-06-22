using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Interfaces
{
    public interface IDateWiseTripRepository : IGenericRepository<DateWiseTrip>
    {
        List<DateWiseTrip> GetDateWiseByTrip(int id, DateTime date);
        IEnumerable<DateWiseTrip> GetDateWiseTrip(int tripId);
        int SoftDelete(int id);
    }
}
