using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessManagementSystem.Models.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Code")]
        [StringLength(20, MinimumLength = 6)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(100, MinimumLength = 6)]
        public string Name { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}
