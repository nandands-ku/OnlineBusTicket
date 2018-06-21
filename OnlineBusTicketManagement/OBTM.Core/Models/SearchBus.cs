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
        public int From { get; set; }
        public int To { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        [Display(Name ="Departure Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DepartureDate { get; set; }

        public virtual ICollection<DateWiseTrip> GetDateWiseTrip { get; set; }
        public int RouteId { get; set; }
        public virtual OperatorRouteMap GetOperatorRouteMap { get; set; }
        public virtual TripBase GetTripBase { get; set; }
        public int BusOperatorId { get; set; }
        public virtual BusOperator GetBusOperator { get; set; }



    }
}
