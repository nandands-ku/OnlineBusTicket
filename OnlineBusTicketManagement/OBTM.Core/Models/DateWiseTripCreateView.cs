using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
    public class DateWiseTripCreateView
    {
        public int BusOperatorId { get; set; }
        public int RouteId { get; set; }
        public int TripId { get; set; }

        public int DateWiseTripId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Range(0, 40,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Number Of Seat")]
        public int NoOfSeat { get; set; }

        [Range(0, maximum: Int32.MaxValue,
        ErrorMessage = "Value for {0} must be between {1}Tk to a reasonable fare.")]
        public int Fare { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }
    }
}
