using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformation.BusinessEntity
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }


        [Range(0,99,ErrorMessage ="Please Enter proper range for categoryId")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Please enter Product Name")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

    }
}
