using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; } // System Generated




        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; }




        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; } // Foreign Key
        public Course Course { get; set; }




        [Required]
        public DateTime EnrollmentDate { get; set; } // User Input

        [MaxLength(2)]
        public string? FinalGrade { get; set; } // User Input/// استخدمنا ? لأنOptional


        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "In Progress"; // Default Value
    }
}
