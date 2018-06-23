namespace OBTM.Core.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OBTMDbContext : DbContext
    {
        public OBTMDbContext()
            : base("name=Online_BTM")
        {
        }

        public virtual DbSet<BookingTicket> BookingTickets { get; set; }
        public virtual DbSet<BusOperator> BusOperators { get; set; }
        public virtual DbSet<DateWiseTrip> DateWiseTrips { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<OperatorRouteMap> OperatorRouteMaps { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RoutePoints> RoutePoints { get; set; }
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

            //modelBuilder.Entity<DateWiseTrip>()
            //    .HasMany(e => e.BookingTickets)
            //    .WithRequired(e => e.DateWiseTrips)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Locations>()
            //    .HasMany(e => e.RoutePoints)
            //    .WithRequired(e => e.Locations)
            //    .HasForeignKey(e => e.LocationId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.OperatorRouteMap)
            //    .WithRequired(e => e.Route)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.RoutePoints)
            //    .WithRequired(e => e.Route)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Route>()
            //    .HasMany(e => e.TripBase)
            //    .WithRequired(e => e.Route)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<TripBase>()
                .HasMany(e => e.DateWiseTrip)
                .WithRequired(e => e.TripBase)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<BusOperator>()
               .HasMany(e => e.TripBases)
               .WithRequired(e => e.BusOperator)
               .WillCascadeOnDelete(false);
        }

    }
}
