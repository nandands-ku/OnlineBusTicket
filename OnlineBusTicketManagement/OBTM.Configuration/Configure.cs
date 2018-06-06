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

            container.RegisterType<IUserRepository, UserDataAccess>();
            container.RegisterType<IGenericRepository<User>, GenericDataAccess<User>>();
            
            container.RegisterType<IRouteRepository, RouteDataAccess>();
            container.RegisterType<IGenericRepository<Route>, GenericDataAccess<Route>>();
            container.RegisterType<ILocationsRepository, RoutePointDataAccess>();
            container.RegisterType<IGenericRepository<Locations>, GenericDataAccess<Locations>>();

            container.RegisterType<ITripBaseRepository, TripBaseDataAccess>();
            container.RegisterType<IGenericRepository<TripBase>, GenericDataAccess<TripBase>>();
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
