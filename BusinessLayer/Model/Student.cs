using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        
        [Required(ErrorMessage = "Name is required.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        public int BloodGroupId { get; set; }
        public int CourseId { get; set; }
        //public ICollection<Course> Courses { get; set; }
        //public BloodGroup BloodGroup { get; set; }



    }
}
