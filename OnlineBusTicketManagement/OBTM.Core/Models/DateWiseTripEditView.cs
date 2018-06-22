using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
    public class DateWiseTripEditView
    {
        public DateWiseTrip DateWiseTrip { get; set; }
        public int BusOperatorId { get; set; }
        public int RouteId { get; set; }
        public int TripId { get; set; }

    }
}
