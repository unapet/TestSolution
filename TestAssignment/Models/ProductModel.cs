using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please enter the title of your product")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
