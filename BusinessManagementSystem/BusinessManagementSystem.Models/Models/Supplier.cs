using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BusinessManagementSystem.Models.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Code")]
        [StringLength(20, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(300, MinimumLength = 3)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(300, MinimumLength = 3)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [StringLength(300, MinimumLength = 3)]
        [RegularExpression(@"^(([^<>()[\]\\.,;:\s@""]+(\.[^<>()[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Contact")]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^[0-9]{8,11}$", ErrorMessage = "Invalid Contact Number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Person")]
        [StringLength(300, MinimumLength = 3)]
        [DisplayName("Contact Person")]
        public string ContactPerson { get; set; }

        [NotMapped]
        public List<Supplier> Suppliers { get; set; }
    }
}
