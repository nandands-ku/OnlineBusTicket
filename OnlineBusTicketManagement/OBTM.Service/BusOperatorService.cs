﻿using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using System.Collections.Generic;

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
        public Response<int> SaveEditedBus(BusOperator bus)
        {
            var repository = GetInstance<IBusOpertaorRepository>();
            var result = SafeExecute(() => repository.SaveEditedBus(bus));
            return result;
        }
        public Response<int> DeleteBusSoft(int id)
        {
            var repository = GetInstance<IBusOpertaorRepository>();
            var result = SafeExecute(() => repository.DeleteBusSoft(id));
            return result;
        }
    }
}
