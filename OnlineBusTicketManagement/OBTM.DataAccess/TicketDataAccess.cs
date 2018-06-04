using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class TicketDataAccess : GenericDataAccess<Ticket>, ITicketRepository
    {
        public TicketDataAccess(OBTMDbContext context) : base(context)
        {

        }
    }
}
