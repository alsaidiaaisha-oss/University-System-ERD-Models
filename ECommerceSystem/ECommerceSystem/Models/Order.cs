using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class Order
    {


            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int OrderId { get; set; } // System Generated

            [ForeignKey(nameof(User))]
            public int UserId { get; set; } // Foreign Key

        public virtual User User { get; set; }

            [Required]
           
            public DateTime OrderDate { get; set; } // User Input


            [Required]
            [Range(typeof(decimal), "0", "999999999")]
            [Column(TypeName = "decimal(18,2)")]
            public decimal TotalAmount { get; set; } // User Input



          


            [Required]
            [MaxLength(30)]
            public string Status { get; set; } = "Pending"; // Default Value

            [Required]
            [MaxLength(300)]
            public string  ShippingAddress { get; set; } // User Input

            [Required]
            [MaxLength(50)]
            public string PaymentMethod { get; set; } // User Input





        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();




    }
    }



