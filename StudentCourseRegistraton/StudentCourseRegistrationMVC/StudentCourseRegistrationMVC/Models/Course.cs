using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace StudentCourseRegistrationMVC.Models
{

        [Table("Course")]
        public partial class Course
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            public int courseId { get; set; }

            [Required]
            [StringLength(20)]
            public string courseName { get; set; }

            [Required]
            [StringLength(30)]
            public string courseDetail { get; set; }

            [Required]
            [StringLength(10)]
            public string duration { get; set; }

            [Required]
            [StringLength(20)]
            public string fees { get; set; }


        }
    
}