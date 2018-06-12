using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class RouteService : GenericService<Route>
    {
        public IEnumerable<Route> GetRefinedRoutes(int busOperatorId)
        {
            var routeRepository = GetInstance<IRouteRepository>();
            var result = SafeExecute(() => routeRepository.GetRefinedRoutes(busOperatorId));
            return result.Data;
        }
    }
}
