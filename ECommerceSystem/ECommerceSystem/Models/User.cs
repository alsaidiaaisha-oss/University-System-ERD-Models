using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceSystem.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // System Generated


        [Required]
        [MaxLength(50)]
        public string Username { get; set; } // User Input


        [Required]
        [MaxLength(150)]
        public string Email { get; set; } // User Input


        [Required]
        [MaxLength(256)]
        public string PasswordHash { get; set; } // User Input


        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } // User Input



        [MaxLength(20)]
        public string? PhoneNumber { get; set; } // User Input


        [MaxLength(300)]
        public string? Address { get; set; } // User Input

        [Required]
        public DateTime RegistrationDate { get; set; } // User Input


        public bool IsActive { get; set; } = true; // Default Value


        //  يستطيع الوصول إلى جميع الطلبات وجميع المراجعات
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();


    }
}
