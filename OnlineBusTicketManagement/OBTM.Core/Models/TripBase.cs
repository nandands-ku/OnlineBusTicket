namespace OBTM.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum BusType
    {
        AC,
        NonAC
    }

    [Table("TripBase")]
    public partial class TripBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TripBase()
        {
            DateWiseTrip = new HashSet<DateWiseTrip>();
        }

        public int Id { get; set; }

        public int BusOperatorId { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime DepartureTime { get; set; }

        [Required]
        public BusType BusType { get; set; }

        [Display(Name="Bus Type")]
        public String ShowBusType { get { return Enum.GetName(typeof(BusType), this.BusType); } }

        public int RouteId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual BusOperator BusOperator { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DateWiseTrip> DateWiseTrip { get; set; }

        public virtual Route Route { get; set; }
    }
}
