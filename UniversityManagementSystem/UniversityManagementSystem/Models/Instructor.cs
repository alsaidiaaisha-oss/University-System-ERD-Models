using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public  class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } // User Input

        [MaxLength(20)]
        public string? OfficeNumber { get; set; } // User Input


        [Required]
        public DateTime HireDate { get; set; } // User Input


        [Required]
        [Range(typeof(decimal), "0.01", "999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; } // User Input


        [Required]
        [MaxLength(50)]
        public string AcademicTitle { get; set; } // User Input


        public ICollection<Course> Courses { get; set; } = new List<Course>();

        public Department? HeadDepartment { get; set; }
    }
}


