using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class OperatorRouteMapService:GenericService<OperatorRouteMap>
    {
        public Response<int> DeleteOperatorRouteSoft(int id)
        {
            var repository = GetInstance<IOperatorRouteMapRepository>();
            var result = SafeExecute(() => repository.DeleteOperatorRouteSoft(id));
            return result;
        }

        public Response<int> DeleteSingleRouteForBus(int id)
        {
            var repository = GetInstance<IOperatorRouteMapRepository>();
            var result = SafeExecute(() => repository.DeleteSingleRouteForBus(id));
            return result;
        }
    }

}
