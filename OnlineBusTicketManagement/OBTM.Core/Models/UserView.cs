using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBTM.Core.Models
{
    public class UserView
    {
        [Required(ErrorMessage ="Enter UserName")]
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        [Required(ErrorMessage ="Enter Password")]
        [StringLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
