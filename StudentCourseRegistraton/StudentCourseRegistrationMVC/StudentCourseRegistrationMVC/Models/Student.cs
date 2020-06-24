namespace StudentCourseRegistrationMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int studentId { get; set; }

        [Required]
        [StringLength(20)]
        public string studentName { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string phoneNo { get; set; }

        [Required]
        [StringLength(20)]
        public string country { get; set; }

        [Required]
        [StringLength(20)]
        public string userName { get; set; }

        [Required]
        [StringLength(20)]
        public string password { get; set; }
    }
}
