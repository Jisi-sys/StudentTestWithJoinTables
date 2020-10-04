using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class BloodGroup
    {

        [Key]
        public int BloodGroupId { get; set; }
        [Required]
        public string BloodGroupName { get; set; }

        //public ICollection<Student> Students { get; set; }
        //if we are using Entity Framework ,then only we have to specify the realtionship between the tables.
        //otherwise, we can directly give that in our db itself.
    }
}

