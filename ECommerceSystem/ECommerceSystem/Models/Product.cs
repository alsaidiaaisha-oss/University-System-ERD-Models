using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } // System Generated

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; } // User Input

        [MaxLength(1000)]
        public string? Description { get; set; } // User Input


        [Required]
        [Range(typeof(decimal), "0.01", "999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // User Input


        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0; // Default Value

        [MaxLength(300)]
        public string? ImageUrl { get; set; } // User Input

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; } // Foreign Key

        public virtual Category Category { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } // User Input

        public bool IsAvailable { get; set; } = true; // Default Value


        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
