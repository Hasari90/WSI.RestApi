using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using RestApi.Models;

namespace RestApi.Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> list;

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student model)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Student model)
        {
            throw new NotImplementedException();
        }
    }
}
