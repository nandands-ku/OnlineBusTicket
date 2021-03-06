﻿using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public class BusOpertaorDataAccess : GenericDataAccess<BusOperator>, IBusOpertaorRepository
    {
     
        public BusOpertaorDataAccess(OBTMDbContext context) : base(context)
        {
          
       
                    
        }
        public int SaveEditedBus(BusOperator bus)
        {
            var b= OBTMDbContext.BusOperators.Where(i => i.Id == bus.Id).Single();
            b.Name = bus.Name;
            b.Email = bus.Email;
            OBTMDbContext.Entry(b).State = EntityState.Modified;
            return OBTMDbContext.SaveChanges();
        }
        public int DeleteBusSoft(int id)
        {
            var obj = OBTMDbContext.BusOperators.Find(id);
            obj.IsDeleted = true;
            OBTMDbContext.Entry(obj).State = EntityState.Modified;
            

            return OBTMDbContext.SaveChanges();
        }
    }
}
