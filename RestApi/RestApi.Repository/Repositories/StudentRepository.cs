using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestApi.Model;
using MongoDB.Driver;

namespace RestApi.Repository.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private List<Student> list = new List<Student>();

        private IMongoCollection<Student> mongoCollection;

        public StudentRepository()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("RestApi");

            mongoCollection = db.GetCollection<Student>("students");
        }

        public bool Delete(string id)
        {
            try
            {
                var student = GetById(id);
                if (student != null)
                    list.RemoveAll(s => s.Index == Convert.ToInt32(id));
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Student> GetAll()
        {
            //return mongoCollection.Find(Builders<Student>.Filter.Empty).ToEnumerable();
            return list;
        }

        public Student GetById(string id)
        {
            var student = list.FirstOrDefault(s => s.Index == Convert.ToInt32(id));
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
            student.Grades = model.Grades;
        }
    }
}
