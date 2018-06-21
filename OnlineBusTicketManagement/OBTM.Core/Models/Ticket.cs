namespace OBTM.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Passenger's Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name ="Cell No")]
        public string CellNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Total Fare")]
        public decimal TotalFare { get; set; }

        [Required]
        [StringLength(50)]
        public string Seats { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="Ticket Pin")]
        public string TicketPIN { get; set; }
        
        public string CreditCard { get; set; }
        public int DateWiseTripId { get; set; }
        public List <BookingTicket> Bookings { get; set; }

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
