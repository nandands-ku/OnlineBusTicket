using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Interfaces
{
    public interface IRouteRepository: IGenericRepository<Route>
    {
       IEnumerable<Route> GetRefinedRoutes(int busOperatorId);
    }
}
