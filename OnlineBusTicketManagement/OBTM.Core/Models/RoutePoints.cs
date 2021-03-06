namespace OBTM.Core.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RoutePoints")]
    public partial class RoutePoints
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int LocationId { get; set; }

        public bool IsFrom { get; set; }

        public bool IsTo { get; set; }

        public int SequenceId { get; set; }

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
