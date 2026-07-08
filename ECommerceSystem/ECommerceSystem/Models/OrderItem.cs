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

        public virtual Order Order { get; set; }



        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; } // Foreign Key

        public virtual Product Product { get; set; }

        [Required]
        [Range(1, 999)]
        public int Quantity { get; set; } // User Input


        [Required]
        [Range(typeof(decimal), "0.01", "999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // From Product Price
    }
}
