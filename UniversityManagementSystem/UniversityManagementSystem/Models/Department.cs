using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagementSystem.Models
{
    public  class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; } // System Generated

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; } // User Input


        [MaxLength(50)]
        public string? Building { get; set; } // User Input

        [Required]
        [Range(typeof(decimal), "0", "999999999")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; } // User Input

        ////////////Foreign Key /////////////////////////////////////

       


        [ForeignKey(nameof(HeadInstructor))]
        public int? HeadInstructorId { get; set; } // Foreign Key //// أي يمكن أن يكون القسم بدون رئيس

        public Instructor? HeadInstructor { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }

}
