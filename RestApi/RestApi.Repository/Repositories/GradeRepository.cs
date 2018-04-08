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
                list.RemoveAll(s => s.StudentIndex == id && s.CourseName == course);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Grade GetById(string id, string course)
        {
            var grade = list.First(s => s.StudentIndex == id && s.CourseName == course);
            return grade;
        }

        public IEnumerable<Grade> GetAll()
        {
            return list;
        }

        public Grade GetById(string id)
        {
            var grade = list.First(s => s.StudentIndex == id);
            return grade;
        }

        public void Insert(Grade model)
        {
            list.Add(model);
        }

        public void Update(string id, Grade model)
        {
            var grade = list.First(s => s.StudentIndex == id && s.CourseName == model.CourseName);

            grade.Date = model.Date;
            grade.Mark = model.Mark;
        }

        public bool Delete(string id)
        {
            return false;
        }
    }
}
