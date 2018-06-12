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

        public virtual DbSet<BookingTicket> BookingTicket { get; set; }
        public virtual DbSet<BusOperator> BusOperator { get; set; }
        public virtual DbSet<DateWiseTrip> DateWiseTrip { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<OperatorRouteMap> OperatorRouteMap { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<RoutePoints> RoutePoints { get; set; }
        public virtual DbSet<SeatBase> SeatBase { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TripBase> TripBase { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusOperator>()
                .HasMany(e => e.OperatorRouteMap)
                .WithRequired(e => e.BusOperator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BusOperator>()
                .HasMany(e => e.TripBase)
                .WithRequired(e => e.BusOperator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DateWiseTrip>()
                .HasMany(e => e.BookingTicket)
                .WithRequired(e => e.DateWiseTrip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Locations>()
                .HasMany(e => e.RoutePoints)
                .WithRequired(e => e.Locations)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.OperatorRouteMap)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.RoutePoints)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.TripBase)
                .WithRequired(e => e.Route)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TripBase>()
                .HasMany(e => e.DateWiseTrip)
                .WithRequired(e => e.TripBase)
                .WillCascadeOnDelete(false);
        }
    }
}
