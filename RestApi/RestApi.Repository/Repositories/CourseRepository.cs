using MongoDB.Driver;
using RestApi.Model;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RestApi.Repository.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private List<Course> list = new List<Course>();

        private IMongoCollection<Course> mongoCollection;

        public CourseRepository()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("RestApi");

            mongoCollection = db.GetCollection<Course>("courses");
        }


        public bool Delete(string id)
        {
            try
            {
                var course = GetById(id);
                if (course != null)
                    list.RemoveAll(s => s.Name == id);
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Course> GetAll()
        {
            //return mongoCollection.Find(Builders<Course>.Filter.Empty).ToEnumerable();
            return list;
        }

        public Course GetById(string id)
        {
            var course = list.FirstOrDefault(s => s.Name == id);
            return course;
        }

        public void Insert(Course model)
        {
            if(model != null)
                list.Add(model);
        }

        public void Update(string id, Course model)
        {
            var course = list.First(s => s.Name == id);

            course.Teacher = model.Teacher;
        }
    }
}
