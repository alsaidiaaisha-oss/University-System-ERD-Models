using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderItemId { get; set; } // System Generated

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; } // Foreign Key

        public Order Order { get; set; }



        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; } // Foreign Key

        public Product Product { get; set; }

        [Required]
        [Range(1, 999)]
        public int Quantity { get; set; } // User Input
    }
}
