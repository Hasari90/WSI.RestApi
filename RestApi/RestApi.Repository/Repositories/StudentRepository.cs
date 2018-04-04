using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestApi.Model;

namespace RestApi.Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> list = new List<Student>();

        public StudentRepository()
        {

        }

        public bool Delete(string id)
        {
            try
            {
                list.RemoveAll(s => s.Index == Convert.ToInt32(id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Student> GetAll()
        {
            return list;
        }

        public Student GetById(string id)
        {
            var student = list.First(s => s.Index == Convert.ToInt32(id));
            return student;
        }

        public void Insert(Student model)
        {
                list.Add(model);
        }

        public void Update(string id, Student model)
        {
            var student = list.First(s => s.Index == Convert.ToInt32(id));

            student.Name = model.Name;
            student.Lastname = model.Lastname;
            student.Date = model.Date;
        }
    }
}
