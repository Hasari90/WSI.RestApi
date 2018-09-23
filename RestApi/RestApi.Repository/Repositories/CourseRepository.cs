using MongoDB.Driver;
using RestApi.Model;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using RestApi.Parameter;

namespace RestApi.Repository.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private List<Course> list = new List<Course>();
        private IMongoCollection<Course> mongoCollection;
        private StudentRepository studentRepository;

        public CourseRepository()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("RestApi");

            mongoCollection = db.GetCollection<Course>("courses");
            var options = new CreateIndexOptions() { Unique = true };
            var field = new StringFieldDefinition<Course>("Name");
            var indexDefinition = new IndexKeysDefinitionBuilder<Course>().Ascending(field);
            mongoCollection.Indexes.CreateOne(indexDefinition, options);

            studentRepository = new StudentRepository();
        }


        public bool Delete(string id)
        {
            try
            {
                var students = Enumerable.ToList(studentRepository.GetAll());

                foreach (var student in students)
                {
                    if (student.Grades.Any(g => g.CourseName == id))
                    {
                        student.Grades.RemoveAll(g => g.CourseName == id);
                        studentRepository.Update(student.Index.ToString(), student);
                    }
                }

                mongoCollection.DeleteOne(c => c.Name == id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Course> GetAll()
        {
            return mongoCollection.Find(Builders<Course>.Filter.Empty).ToEnumerable();
        }

        public IEnumerable<Course> GetAll(CourseParameter courseParameter = null)
        {
            var builder = Builders<Course>.Filter;
            var filter = builder.Empty;

            if (courseParameter != null)
            {
                //if (courseParameter.Name != null)
                //    filter &= builder.Where(
                //        student => student.Name.ToLower().Contains(courseParameter.Name.ToLower()));

                //if (courseParameter.Teacher != null)
                //    filter &= builder.Where(
                //        student => student.Teacher.ToLower().Contains(courseParameter.Teacher.ToLower()));
            }

            return mongoCollection.Find(filter).ToEnumerable();
        }

        public Course GetById(string id)
        {
            try
            {
                var course = mongoCollection.AsQueryable<Course>().Where(c => c.Name == id).Single();
                return course;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public void Insert(Course model)
        {
            if(model != null)
            {
                mongoCollection.InsertOne(model);
            }
        }

        public void Update(string id, Course model)
        {
            //var filter = Builders<Course>.Filter.And(
            //                    Builders<Course>.Filter.Where(c => c.Name == id));

            //var update = Builders<Course>.Update
            //    .Set("Name", model.Name)
            //    .Set("Teacher", model.Teacher);

            //mongoCollection.UpdateOne(filter, update);
        }
    }
}
