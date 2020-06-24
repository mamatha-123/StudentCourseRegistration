using Microsoft.Ajax.Utilities;
using NUnit.Framework;
using StudentCourseRegistrationMVC.Controllers;
using StudentCourseRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCourseRegistrationMVC.Test
{
    [TestFixture]
    public class StudentControllerTest
    {
        [Test]
        public void StudentListActionReturnsStudentList()
        {
            string expected = "StudentList";
            var controller = new StudentController();

            var result = controller.StudentList() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }
       
        //[Test]
        //public void RegisterActionReturnsRegister()
        // {
        //    var expectedmsg = "hai";
        //     var controller = new StudentController();
        //     Student st = new Student();
        //     st.studentName = "Ramu";
        //     st.userName = "Muni";
        //     st.phoneNo = "1234567890";
        //     st.password = "12345";
        //     st.email = "ramamuni.boreddy@gmail.com";
        //     st.country = "India";
        //     JsonResult result = controller.Register(st) as JsonResult;
        //    // JSON.stringify(k1) === JSON.stringify(k2)
        //     Assert.AreEqual(expectedmsg, result);
        // }
    }
}