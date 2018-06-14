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
            container.RegisterType<IGenericRepository<Ticket>, GenericDataAccess<Ticket>>();

            container.RegisterType<ISeatBaseRepository, SeatBaseDataAccess>();
            container.RegisterType<IGenericRepository<SeatBase>, GenericDataAccess<SeatBase>>();

            container.RegisterType<IUserRepository, UserDataAccess>();
            container.RegisterType<IGenericRepository<User>, GenericDataAccess<User>>();
            
            container.RegisterType<IRouteRepository, RouteDataAccess>();
            container.RegisterType<IGenericRepository<Route>, GenericDataAccess<Route>>();
            container.RegisterType<IRoutePointsRepository, RoutePointsDataAccess>();
            container.RegisterType<IGenericRepository<RoutePoints>, GenericDataAccess<RoutePoints>>();

            container.RegisterType<ITripBaseRepository, TripBaseDataAccess>();
            container.RegisterType<IGenericRepository<TripBase>, GenericDataAccess<TripBase>>();

            container.RegisterType<IOperatorRouteMapRepository, OperatorRouteMapDataAccess>();
            container.RegisterType<IGenericRepository<OperatorRouteMap>, GenericDataAccess<OperatorRouteMap>>();

            container.RegisterType<IOperatorRouteMapRepository, OperatorRouteMapDataAccess>();
            container.RegisterType<IGenericRepository<OperatorRouteMap>, GenericDataAccess<OperatorRouteMap>>();

            container.RegisterType<ILocationsRepository, LocationsDataAccess>();
            container.RegisterType<IGenericRepository<Locations>, GenericDataAccess<Locations>>();
            container.RegisterType<IDateWiseTripRepository, DateWiseTripDataAccess>();
            container.RegisterType<IGenericRepository<DateWiseTrip>, GenericDataAccess<DateWiseTrip>>();
            container.RegisterType<IBookingTicketRepository, BookingTicketDataAccess>();
            container.RegisterType<IGenericRepository<BookingTicket>, GenericDataAccess<BookingTicket>>();
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
