using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
   public class SeatBaseDataAccess : GenericDataAccess<SeatBase>, ISeatBaseRepository
    {
        public SeatBaseDataAccess(OBTMDbContext context) : base(context)
        {
        }

        public string GetSeatName(int seatId)
        {
            string seatName = OBTMDbContext.SeatBases.Where(seat=> seat.Id==seatId).Select(seat=> seat.SeatName).FirstOrDefault().ToString() ;
            return seatName;
        }
    }
}
