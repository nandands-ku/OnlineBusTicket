using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
   public class SearchBus
    {
        public string From { get; set; }
        public string To { get; set; }
        [Display(Name ="Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        public virtual DateWiseTrip GetDateWiseTrip { get; set; }
        public int RouteId { get; set; }
        public virtual OperatorRouteMap GetOperatorRouteMap { get; set; }

        public int BusOperatorId { get; set; }
        public virtual BusOperator GetBusOperator { get; set; }


    }
}
