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

        [Required(ErrorMessage = "Mobile Number is required.")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name ="Cell No")]
        public string CellNo { get; set; }

        [Required(ErrorMessage = "Please provide a valid Email Id")]
        [DataType(DataType.EmailAddress)]
        
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

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^([0-9]{9})$", ErrorMessage = "Invalid Credit Card no.")]
        [Display(Name = "Credit Card")]
        public string CreditCard { get; set; }
        
        //public virtual List <BookingTicket> Bookings { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        //public int DateWiseTripID { get; set; }
    }
}
