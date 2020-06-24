using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
namespace StudentCourseRegistrationMVC.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext() : base("ConnectionStr")
        { 

        }

        public DbSet <Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
    }
}