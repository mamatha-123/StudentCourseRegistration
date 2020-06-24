using StudentCourseRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentCourseRegistrationMVC.Service
{
    public class Connected
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection ConnectionEstablish()
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
            con = new SqlConnection(cs);
            return con;
        }



        /*public List<Course1> getCourseDetails()
       {
            List<Course1> listCourse = new List<Course1>();


            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *  FROM dbo.Course1 ";

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Course1 c = new Course1();
                c.CourseId = rdr.GetInt32(0);
                c.CourseName = rdr.GetString(1);
                c.CourseDetail = rdr.GetString(2);
                c.Duration = rdr.GetString(3);
                c.Fees = rdr.GetString(4);
                listCourse.Add(c);
            }

            return listCourse;


        }*/
        public Boolean CreateData(Student s)
        {
            Boolean successFlag = false;
            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into dbo.Student values (@studentId ,@studentName,@email,@phoneNo,@country,@userName,@password)";
            cmd.Parameters.AddWithValue("@studentId", s.studentId);
            cmd.Parameters.AddWithValue("@studentName", s.studentName);
            cmd.Parameters.AddWithValue("@email", s.email);
            cmd.Parameters.AddWithValue("@phoneNo", s.phoneNo);
            cmd.Parameters.AddWithValue("@country", s.country);
            cmd.Parameters.AddWithValue("@userName", s.userName);
            cmd.Parameters.AddWithValue("@password", s.password);
            con.Open();

            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                successFlag = true;
            }
            return successFlag;

        }

        public Boolean DeleteData(int studentid)
        {
            Boolean successFlag = false;
            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = " DELETE dbo.Student WHERE studentid=@studentid";
            cmd.Parameters.AddWithValue("@studentid", studentid);
            con.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                successFlag = true;
            }
            return successFlag;

        }


        public Student StudentData(int studentId)
        {
            Boolean successFlag = false;

            Student st = new Student();
            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM dbo.Student WHERE studentId=@studentId";
            cmd.Parameters.AddWithValue("@studentId", studentId);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                st.studentId = rdr.GetInt32(0);
                st.studentName = rdr.GetString(1);
                st.email = rdr.GetString(2);
                st.phoneNo = rdr.GetString(3);
                st.country = rdr.GetString(4);
                st.userName = rdr.GetString(5);
                st.password = rdr.GetString(6);
            }
            return st;

        }
        public long getMaxStudentID()
        {
            long studentID = 0;
            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT MAX(studentId) studentId FROM dbo.Student ";
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                studentID = rdr.GetInt32(0);

            }
            return studentID;


        }

        public Student getStudentInfo(String username, string password)
        {
            Student st = new Student();

            con = ConnectionEstablish();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *  FROM dbo.Student where userName=@userName and password=@password";
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@password", password);

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                st.studentId = rdr.GetInt32(0);
                st.studentName = rdr.GetString(1);
                st.email = rdr.GetString(2);
                st.phoneNo = rdr.GetString(3);
                st.country = rdr.GetString(4);

            }

            return st;
        }

        public List<Student> getStudentList()
        {

            List<Student> studentList = new List<Student>();
            
            con = ConnectionEstablish();
            cmd=con.CreateCommand();
            cmd.CommandText = "SELECT *  FROM dbo.Student";
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Student st = new Student();
                st.studentId = rdr.GetInt32(0);
                st.studentName = rdr.GetString(1);
                st.email = rdr.GetString(2);
                st.phoneNo = rdr.GetString(3);
                st.country = rdr.GetString(4);
                st.userName = rdr.GetString(5);
                studentList.Add(st);
            }
            return studentList;
        }

    }
}