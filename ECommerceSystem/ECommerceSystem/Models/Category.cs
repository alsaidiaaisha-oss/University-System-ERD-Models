using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } // User Input

        [MaxLength(500)]
        public string? Description { get; set; } // User Input

        [MaxLength(300)]
        public string? ImageUrl { get; set; } // User Input

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
