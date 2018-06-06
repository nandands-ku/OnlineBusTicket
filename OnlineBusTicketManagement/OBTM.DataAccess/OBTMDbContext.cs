using OBTM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.DataAccess
{
    public partial class OBTMDbContext : DbContext
    {
        public OBTMDbContext()
            : base("name=Online_BTM")
        {
        }

        public virtual DbSet<BookingTicket> BookingTickets { get; set; }
        public virtual DbSet<BusOperator> BusOperators { get; set; }
        public virtual DbSet<DateWiseTrip> DateWiseTrips { get; set; }
        public virtual DbSet<RoutePoints> RoutePoints { get; set; }
        public virtual DbSet<OperatorRouteMap> OperatorRouteMaps { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<SeatBase> SeatBases { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TripBase> TripBases { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusOperator>()
                .HasMany(e => e.OperatorRouteMaps)
                .WithRequired(e => e.BusOperator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.TripBases)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);
        }
    }
}
