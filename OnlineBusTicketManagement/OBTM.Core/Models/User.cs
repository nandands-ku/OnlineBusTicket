using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace OBTM.Core.Models
{

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name ="User Name")]
        [Remote("IsUserNameExist", "User",HttpMethod ="POST",ErrorMessage ="User Name already Exist")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Remote("IsEmailExist", "User", HttpMethod = "POST", ErrorMessage = "Email already registered")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(128)]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
