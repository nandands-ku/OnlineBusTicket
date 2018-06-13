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
        public List<int> GetRoute(int UserFrom, int UserTo)
        {
            
            var routeList = (from T1 in OBTMDbContext.RoutePoints join T2 in OBTMDbContext.RoutePoints on T1.RouteId equals T2.RouteId where T1.LocationId == UserFrom && T2.LocationId == UserTo && T1.SequenceId < T2.SequenceId select T1.RouteId).ToList();

            return routeList;
        }
    }
}
