﻿using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Interfaces
{
    public interface IRoutePointsRepository : IGenericRepository<RoutePoints>
    {
        List<int> GetRoute(int UserFrom, int UserTo);
    }
}
