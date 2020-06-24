using StudentCourseRegistrationMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCourseRegistrationMVC.Service
{
    public class Program
    { 

    //Studentlist sl = new Studentlist();
    //Courselist cl = new Courselist();
    //Trainerlist tl = new Trainerlist();
    //Adminlist al = new Adminlist();
    public static void Main(string[] args)
    {
        /*Course1 cour = new Course1(Admin.CourseID++, "Java", "CoreJava", "120 hours", "600");

        Courselist.lstCourses.Add(cour);

        Trainer train = new Trainer(Admin.TrainerId++, "Netra", "Netra125@gmail.com", "9789456971", "India", "Netra", "PasswordNetra1");

        Trainerlist.lstTrainer.Add(train);*/

        Program program = new Program();
        //program.UserLogin();
    }
    public Student StudentLogin(String username, String password)
    {
        Connected sc = new Connected();

        Student st = sc.getStudentInfo(username, password);

        return st;
    }



        /* private static void AdminFlow()
         {

             Courselist cl1 = new Courselist();
             cl1.DisplayAllCourses();
             Admin ad1 = new Admin();
             ad1.DisplayAllTrainers();
             Program pr3 = new Program();


             //add do while loop for multiple enrollments
             Console.WriteLine("DO YOU WANT TO ENROLL");
             Console.WriteLine("1. Trainer \n2. Course");
             int choice = Convert.ToInt32(Console.ReadLine());

             if (choice == 1)
             {
                 pr3.RegisterTrainer();
             }
             else if (choice == 2)
             {
                 cl1.RegisterCourse();
             }

             Console.WriteLine("REGISTERED SUCCESSFULLY.");
             Console.Read();

         }

         private void studentFlow(long studentId)
         {

             Console.WriteLine("Press any key to exit the process...");
             Console.Read();

         }*/
        public bool RegisterStudent(Student s1)
        {

            Program program = new Program();
            Connected sc = new Connected();
            int studentId = Convert.ToInt32(sc.getMaxStudentID()) + 1;

            s1.studentId = studentId;

            bool value = sc.CreateData(s1);



            return value;
        }


  /*  public void RegisterTrainer()
    {

        Console.WriteLine("ENTER TRAINER DETAILS");
        Trainer t1 = new Trainer();
        long i = t1.TrainerId + 1;

        Console.WriteLine("Enter Name :");
        string s = Console.ReadLine();

        Console.WriteLine("Enter Email :");
        string s1 = Console.ReadLine();

        Console.WriteLine("Enter Phonenumber :");
        string s2 = Console.ReadLine();

        Console.WriteLine("Enter Country :");
        string s3 = Console.ReadLine();

        Console.WriteLine("Enter LoginId :");
        string s4 = Console.ReadLine();

        Console.WriteLine("Enter Password:");
        string s5 = Console.ReadLine();
        Trainer objTrainer = new Trainer(i, s, s1, s2, s3, s4, s5);
        tl.NewTrainer(objTrainer);
        Console.WriteLine("PROVIDE DETAILS FOR TRAINER FOR LOGIN \n");
        Trainerlist.lstTrainer.Add(objTrainer);
        Program pr2 = new Program();
        // pr2.UserLogin();

    }



    public void SelectCourseToTeach(long trainerId)
    {
        Student objstu = new Student();
        Console.WriteLine("ENTER VALID COURSE ID THAT YOU WANT TO ENROLL\n");
        Courselist cl1 = new Courselist();
        cl1.DisplayAllCourses();
        int CourseID = Convert.ToInt32(Console.ReadLine());
        int check = cl1.CheckForCourse(CourseID);
        if (check == 1)
        {
            foreach (var obj in Trainerlist.lstTrainer)
            {
                if (obj.TrainerId == trainerId)
                {
                    obj.coursesAssociatedwith.Add(CourseID, trainerId);
                }
            }

        }
        else
        {
            Console.WriteLine("Invalid Course ID");
            SelectCourseToTeach(trainerId);
        }
        Console.WriteLine("Press any key to exit the process...");
        Console.Read();

    }*/




}
}