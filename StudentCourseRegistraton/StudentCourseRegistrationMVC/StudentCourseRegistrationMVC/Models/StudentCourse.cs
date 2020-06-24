using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentCourseRegistrationMVC.Models
{
    [Table("StudentCourse")]
    public  partial class StudentCourse
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        [Required]
        public int studentId { get; set; }

        [Required]
        public int courseId { get; set; }
   

    }
}