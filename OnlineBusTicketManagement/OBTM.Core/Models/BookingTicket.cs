using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OBTM.Core.Models
{

    [Table("BookingTicket")]
    public partial class BookingTicket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SeatName { get; set; }

        public int DateWiseTripId { get; set; }

        public int? TicketId { get; set; }

        public bool? IsTempLocked { get; set; }

        public bool? IsBooked { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
