using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
    public class DateWiseTripView
    {
        public BusOperator BusOperator { get; set; }
        public Route Route { get; set; }
        public TripBase TripBase { get; set; }
        public virtual IEnumerable<DateWiseTrip> DateWiseTripList { get; set; }
    }
}
