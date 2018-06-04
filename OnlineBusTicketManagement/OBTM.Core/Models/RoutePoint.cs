namespace OBTM.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoutePoint")]
    public partial class RoutePoint
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
