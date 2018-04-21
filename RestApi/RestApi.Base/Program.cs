using RestApi.Model;
using RestApi.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Base
{
    public class Program
    {
        public static CourseRepository courseRepository = new CourseRepository();
        public static StudentRepository studentRepository = new StudentRepository();
        public static GradeRepository gradeRepository = new GradeRepository();


        static void Main(string[] args)
        {
            //courseRepository.Insert(new Course() { Name = "Matematyka", Teacher = "Jan Pi" });
            //courseRepository.Insert(new Course() { Name = "Biologia", Teacher = "Anna Zieleń" });

            //var course = courseRepository.GetAll().ToList();

            //foreach(Course c in course)
            //{
            //    Console.WriteLine(c.Name + " " + c.Teacher);
            //}

            //studentRepository.Insert(new Student() { Index = 100236, Name = "Adam", Lastname = "Grosz", Date = DateTime.Now });
            //studentRepository.Insert(new Student() { Index = 101236, Name = "Jan", Lastname = "Czas", Date = new DateTime(1990,12,2) });

            //var student = studentRepository.GetAll();

            //foreach (Student s in student)
            //{
            //    Console.WriteLine(s.Name + " " + s.Lastname + " " + s.Index.ToString());
            //}

            //gradeRepository.Insert(new Grade() { Mark = 5.0, Date = DateTime.Now, CourseName = "Matematyka", StudentIndex = "100236" });

            //gradeRepository.GetAll();

            Console.ReadKey();

        }
    }
}
