using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; } // System Generated

        [ForeignKey(nameof(User))]
        public int UserId { get; set; } // Foreign Key

        public User User { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; } // Foreign Key

        public Product Product { get; set; }


        [Required]
        [Range(1, 5)]
        public int Rating { get; set; } // User Input

        [MaxLength(1000)]
        public string? Comment { get; set; } // User Input

        public DateTime ReviewDate { get; set; }// User Input




    }
}
