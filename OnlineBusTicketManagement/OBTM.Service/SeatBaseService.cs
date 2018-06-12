using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Service
{
    public class SeatBaseService : GenericService<SeatBase>
    {
        public string GetSeatName(int seatId)
        {
            var seatBaseRepository = GetInstance<ISeatBaseRepository>();
            var result = SafeExecute(() => seatBaseRepository.GetSeatName(seatId));
            return result.Data;
        }
    }

}
