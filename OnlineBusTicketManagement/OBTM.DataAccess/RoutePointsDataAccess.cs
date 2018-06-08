using OBTM.Core.Models;
using OBTM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class RoutePointsDataAccess : GenericDataAccess<RoutePoints> , IRoutePointsRepository
    {
        public RoutePointsDataAccess(OBTMDbContext context) : base(context)
        {
        }
    }
}
