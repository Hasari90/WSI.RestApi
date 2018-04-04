using RestApi.Model;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApi.Repository.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private List<Course> list = new List<Course>();



        public bool Delete(string id)
        {
            try
            {
                list.RemoveAll(s => s.Name == id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Course> GetAll()
        {
            return list;
        }

        public Course GetById(string id)
        {
            var course = list.First(s => s.Name == id);
            return course;
        }

        public void Insert(Course model)
        {
            list.Add(model);
        }

        public void Update(string id, Course model)
        {
            var course = list.First(s => s.Name == id);

            course.Teacher = model.Teacher;
            course.Grades = model.Grades;
        }
    }
}
