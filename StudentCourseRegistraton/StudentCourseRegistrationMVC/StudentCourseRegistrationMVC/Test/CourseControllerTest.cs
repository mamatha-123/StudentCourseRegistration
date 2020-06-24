using NUnit.Framework;
using StudentCourseRegistrationMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCourseRegistrationMVC.Test
{ 

    [TestFixture]
public class CourseControllerTest
    {

    [Test]
    public void CourseListActionReturnstCourseList()
    {
        string expected = "CourseList";
        var controller = new CourseController();

        var result = controller.CourseList() as ViewResult;

        Assert.AreEqual(expected, result.ViewName);
    }

}
}