using Microsoft.ApplicationInsights.Extensibility.Implementation;
using StudentCourseRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCourseRegistrationMVC.Controllers
{
    public class HomeController : Controller
    {

        StudentContext UContext;
        public HomeController()
        {
            UContext = new StudentContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            List<Student> listuser = new List<Student>();
            listuser = UContext.Student.ToList();
            ViewBag.StudentList = listuser.ToArray();
            return View();
            
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}