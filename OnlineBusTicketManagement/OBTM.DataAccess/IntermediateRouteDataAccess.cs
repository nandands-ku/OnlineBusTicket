using OBTM.Core.Models;
using OBTM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class IntermediateRouteDataAccess : GenericDataAccess<IntermediateRoute> , IIntermediateRouteRepository
    {
        public IntermediateRouteDataAccess(OBTMDbContext context) : base(context)
        {
        }
    }
}
