
using OBTM.Core.Models;

namespace OBTM.Core.Interfaces
{
    public interface IBusOpertaorRepository : IGenericRepository<BusOperator>
    {
        int SaveEditedBus(BusOperator bus);
        int DeleteBusSoft(int id);
    }
}
