using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class RoutePointsService : GenericService<RoutePoints>
    {
        public List<int> GetRoute(int UserFrom, int UserTo)
        {
            var repository = GetInstance<IRoutePointsRepository>();
            var result = SafeExecute(() => repository.GetRoute(UserFrom,UserTo));
            return result.Data;
        }

    }
}
