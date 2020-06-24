using StudentCourseRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCourseRegistrationMVC.Controllers
{
    public class CourseController : Controller
    {
        StudentContext UContext;

        public CourseController()
        {
            UContext = new StudentContext();
        }
        // GET: Course
        public ActionResult CourseList()
        {
            List<Course> listOfCourses = new List<Course>();
            listOfCourses = UContext.Course.ToList();
            ViewBag.CoursetList = listOfCourses.ToArray();
            return View("CourseList");     
        }

        public ActionResult Corse()
        {
            List<Course> listOfCourses = new List<Course>();
            listOfCourses = UContext.Course.ToList();
            ViewBag.CoursetList = listOfCourses.ToArray();
            return View("Corse");
            
        }
    }
}