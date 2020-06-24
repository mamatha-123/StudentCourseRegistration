using Microsoft.Ajax.Utilities;
using StudentCourseRegistrationMVC.Models;
using StudentCourseRegistrationMVC.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace StudentCourseRegistrationMVC.Controllers
{

    
    public class StudentController : Controller
    {
        StudentContext UContext;
        public StudentController()
        {
            UContext = new StudentContext();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentList()
        {

            List<Student> listuser = new List<Student>();
            listuser = UContext.Student.ToList();
            var OrderedStudentList = listuser.OrderBy(x => x.studentName);
            ViewBag.StudentList = OrderedStudentList.ToArray();

            return View("StudentList");
        }

        [HttpPost]
        public ActionResult EnrollCourse(int[] courseIDList)
        {

           
            string msg = "";
            int data = 0;
            try
            {
                for (int index = 0; index < courseIDList.Length; index++)
                {
                    StudentCourse sc = new StudentCourse();
                    int id = UContext.StudentCourse.Max(s => s.id);
                    sc.id = id + 1;
                    sc.studentId = Convert.ToInt32(Session["StudentId"].ToString());
                    sc.courseId = courseIDList[index];
                    UContext.StudentCourse.Add(sc);
                    data = UContext.SaveChanges();
                }

                if (data == 1)
                {
                    msg = "Enrolled Successfully";
                }

                else
                {
                    msg = "Enroll Failed";
                }
            }
            catch (Exception ex)
            {
                msg = "Enroll Failed";
                return Json(new
                {
                    msg
                });

            }

            return Json(new
            {
                msg
            });

        }


        [HttpPost]
        public ActionResult UserLogin(Student st)
        {

            Student student;
            String msg;
            try
            {

                //var value=UContext.Student.Select(s => s.userName == st.userName);
               String username = st.userName;
                String password = st.password;
                Connected con = new Connected();
                 
                con = new Connected();

                student = con.getStudentInfo(username, password);

                if (student.studentName != null)
                {
                    msg = student.studentId.ToString();
                }

                else
                {
                    msg = "UserLogin Failed";
                }
            }
            catch(Exception ex)
            {
                 msg = "UserLogin";
                return Json(new
                {
                    msg
                }) ;

            }

            return Json(new
            {
                msg
            });

        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student st = new Student();
            Connected con = new Connected();
            st=con.StudentData(id);
            Session["StudentID"] = id;
            return View(st);
        }

        public ActionResult SignUp()
        {     
            return View();
        }

       
        [HttpPost]
        public ActionResult Register(Student st) 
        {
            String msg = "";

            try
            {

                int id= UContext.Student.Max(s => s.studentId);
                st.studentId = id + 1; 
                UContext.Student.Add(st);
                int data=UContext.SaveChanges();

                if (data==1)
                { 

                    MailMessage mail = new MailMessage();
                    mail.To.Add(st.email);
                    mail.From = new MailAddress("bhargavreddy5135@gmail.com");
                    mail.Subject = "Reg: Student Registration Confirmation";
                    string Body = "User Registration Successfull!  UserName:" + st.userName + " Password:" + st.password; ;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = new System.Net.NetworkCredential("bhargavreddy5135@gmail.com", "mahender09876"); // Enter senders User name and password  
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    msg = "User SignUp Successfull";            
                }
               
                else
                    msg = "SignUp Failed";
            }

            catch (Exception ex)
            {
                msg=ex.Message;

                return Json(new {
                    msg

                });

            }
           
            return Json(new
            {
                msg
            });
        }
       




    }
}
