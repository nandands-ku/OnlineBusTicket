namespace OBTM.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DateWiseTrip")]
    public partial class DateWiseTrip
    {
        
        public int Id { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public int TripBaseId { get; set; }
        //public virtual TripBase GetTripBase { get; set; }

        [Range(0, 40,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name ="Number Of Seat")]
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
        public virtual TripBase TripBase { get; set; }
        
    }
}
