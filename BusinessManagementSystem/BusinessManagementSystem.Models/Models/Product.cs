using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BusinessManagementSystem.Models.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Code")]
        [StringLength(20, MinimumLength = 3)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Enter Reorder Level")]       
        public int Reorder_Level { get; set; }

        [Required(ErrorMessage = "Please Enter Description")]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select Category")]
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        public List<Product> Products { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
    }
}
