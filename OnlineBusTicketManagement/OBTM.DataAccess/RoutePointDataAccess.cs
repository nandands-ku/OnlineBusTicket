using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class RoutePointDataAccess : GenericDataAccess<RoutePoint>, IRoutePointRepository
    {
        public RoutePointDataAccess(OBTMDbContext context) : base(context)
        {
        }
    }
}
