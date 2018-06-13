using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class LocationsDataAccess : GenericDataAccess<Locations>, ILocationsRepository
    {
        public LocationsDataAccess(OBTMDbContext context) : base(context)
        {
        }
    }
}
