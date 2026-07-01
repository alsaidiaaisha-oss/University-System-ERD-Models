using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; } // System Generated

        [Required]
        [MaxLength(10)]
        public string CourseCode { get; set; } // User Input

        [Required]
        [MaxLength(150)]
        public string CourseTitle { get; set; } // User Input

        [Required]
        [Range(1, 6)]
        public int CreditHours { get; set; } // User Input

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; } // Foreign Key
        public Department Department { get; set; }




        [ForeignKey(nameof(Instructor))]
        public int? InstructorId { get; set; } // Foreign Key////هنا استخدمنا ? لأن المادة قد لا يكون لها مدرس بعد
        public Instructor? Instructor { get; set; }



        [Required]
        [MaxLength(20)]
        public string SemesterOffered { get; set; } // User Input



        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


    }
}
