using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace OBTM.Core.Models
{

    [Table("OperatorRouteMap")]
    public partial class OperatorRouteMap
    {
        public int Id { get; set; }

        public int BusOperatorId { get; set; }

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
        public virtual Route Route { get; set; }
    }
}
