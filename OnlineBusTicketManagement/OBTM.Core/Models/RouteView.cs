using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
   public class RouteView
    {
        //public Route Routes { get; set; }
        public int? RouteId { get; set; }
        public int BusOperatorId { get; set; }
        public int From { get; set; }
        public List<int> Via { get; set; }
        public int To { get; set; }
        public bool IsReverse { get; set; }
        //public int ExistingRoutes { get; set; }
        //public virtual ICollection<RoutePoints> RoutePointsList { get; set; }
    }
}

