using RestApi.Model;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestApi.Repository.Repositories
{
    public class GradeRepository : IRepository<Grade>
    {
        private List<Grade> list = new List<Grade>();

        public bool Delete(string id, string course)
        {
            try
            {
                //list.RemoveAll(s => s.StudentIndex == id && s.CourseName == course);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(string id, string course, int grade)
        {
            try
            {
                //list.RemoveAll(s => s.StudentIndex == id && s.CourseName == course && s.Id == grade);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Grade> GetById(string id, string course)
        {
            //var grades = list.Where(s => s.StudentIndex == id && s.CourseName == course);
            //return grades;
            return new List<Grade>();
        }

        public Grade GetById(string id, string course, int grade)
        {
            //var grades = list.FirstOrDefault(s => s.StudentIndex == id && s.CourseName == course && s.Id == grade);
            //return grades;
            return new Grade();
        }

        public IEnumerable<Grade> GetAll()
        {
            return list;
        }

        public Grade GetById(string id)
        {
            //var grade = list.FirstOrDefault(s => s.StudentIndex == id);
            //return grade;
            return new Grade();
        }

        public void Insert(Grade model)
        {
            list.Add(new Grade()
            {
                Id = list.Count,
                Mark = model.Mark,
                Date = model.Date,
               // StudentIndex = model.StudentIndex,
                CourseName = model.CourseName
            });
        }

        public void Update(string id, Grade model)
        {
            // var grade = list.First(s => s.StudentIndex == id && s.CourseName == model.CourseName);
            var grade = new Grade();
            grade.Date = model.Date;
            grade.Mark = model.Mark;
        }

        public void Update(string id, string course, int grade, Grade model)
        {
            //var grades = list.First(s => s.StudentIndex == id && s.CourseName == model.CourseName && s.Id == grade);
            var grades = new Grade();
            grades.Date = model.Date;
            grades.Mark = model.Mark;
        }

        public bool Delete(string id)
        {
            return false;
        }
    }
}
