using RestApi.Models;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Repository.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Course model)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Course model)
        {
            throw new NotImplementedException();
        }
    }
}
