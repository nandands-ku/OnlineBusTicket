using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class BusOperatorService : GenericService<BusOperator>
    {
        public List<BusOperator> GetAllBusOperators()
        {
            var repository = GetInstance<IBusOpertaorRepository>();
            var result = SafeExecute(() => repository.GetAll());
            return result.Data;
        }

    }
}
