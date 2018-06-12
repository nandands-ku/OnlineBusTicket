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
        public int DeleteSoft(object id)
        {
            var obj = OBTMDbSet.Find(id);
            obj.IsDeleted = true;
            OBTMDbContext.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            
            return OBTMDbContext.SaveChanges();
        }
    }
}
