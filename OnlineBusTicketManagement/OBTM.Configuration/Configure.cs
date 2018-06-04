using OBTM.Core.Interfaces;
using OBTM.Core.Models;
using OBTM.DataAccess;
using Unity;

namespace OBTM.Configuration
{
    public class Configure
    {
        private static IUnityContainer _container;

        public static void RegisterMappings(IUnityContainer container)
        {
            _container = container;
            
            container.RegisterType<IBusOpertaorRepository, BusOpertaorDataAccess>();
            container.RegisterType<IGenericRepository<BusOperator>, GenericDataAccess<BusOperator>>();
            container.RegisterType<ITicketRepository, TicketDataAccess>();
            container.RegisterType<ISeatBaseRepository, SeatBaseDataAccess>();

            
            container.RegisterType<IRouteRepository, RouteDataAccess>();
            container.RegisterType<IGenericRepository<Route>, GenericDataAccess<Route>>();
            container.RegisterType<IRoutePointRepository, RoutePointDataAccess>();
            container.RegisterType<IGenericRepository<RoutePoint>, GenericDataAccess<RoutePoint>>();

        }

        public static T GetInstance<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch
            {
                return default(T);
            }
        }
    }
}
