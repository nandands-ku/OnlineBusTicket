namespace OBTM.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripBase")]
    public partial class TripBase
    {
        public int Id { get; set; }
        [Column(TypeName ="Time")]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Bus Type")]
        public string BusType { get; set; }

        public int RouteId { get; set; }
        public Route GetRoute { get; set; }

        public int BusOperatorId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual Route Route { get; set; }
    }
}
