using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class TripBaseService:GenericService<TripBase>
    {
        public Response<int> Delete(int id)
        {
            var repository = GetInstance<ITripBaseRepository>();
            var result = SafeExecute(() => repository.DeleteTrip(id));
            return result;
        }

    }
}
