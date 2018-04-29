using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestApi.Model;
using MongoDB.Driver;
using RestApi.Parameter;

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
            var options = new CreateIndexOptions() { Unique = true };
            var field = new StringFieldDefinition<Student>("Index");
            var indexDefinition = new IndexKeysDefinitionBuilder<Student>().Ascending(field);
            mongoCollection.Indexes.CreateOne(indexDefinition, options);
        }

        public bool Delete(string id)
        {
            try
            {
                mongoCollection.DeleteOne(s => s.Index == Convert.ToInt32(id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<Student> GetAll()
        {
            return mongoCollection.Find(Builders<Student>.Filter.Empty).ToEnumerable();
        }

        public IEnumerable<Student> GetAll(StudentParameter studentParameter = null)
        {
            var builder = Builders<Student>.Filter;
            var filter = builder.Empty;

            if (studentParameter != null)
            {
                if (studentParameter.Name != null)
                    filter &= builder.Where(
                        student => student.Name.ToLower().Contains(studentParameter.Name.ToLower()));

                if (studentParameter.Lastname != null)
                    filter &= builder.Where(
                        student => student.Lastname.ToLower().Contains(studentParameter.Lastname.ToLower()));

                if (studentParameter.Date != null)
                    filter &= builder.Eq("Date", studentParameter.Date);

                if (studentParameter.DateAfter != null)
                    filter &= builder.Gte("Date", studentParameter.DateAfter);

                if (studentParameter.DateBefore != null)
                    filter &= builder.Lte("Date", studentParameter.DateBefore);
            }

            return mongoCollection.Find(filter).ToEnumerable();
        }

        public Student GetById(string id)
        {
            
            try
            {
            var student = mongoCollection.AsQueryable<Student>().Where(s => s.Index == Convert.ToInt32(id)).Single();
                return student;
            }
            catch(Exception)
            {
                return null;
            }  
        }

        public void Insert(Student model)
        {
            if (model != null)
            {
                mongoCollection.InsertOne(model);
            }
        }

        public void Update(string id, Student model)
        {
            var filter = Builders<Student>.Filter.And(
                                Builders<Student>.Filter.Where(s => s.Index == Convert.ToInt64(id)));

            var update = Builders<Student>.Update
                .Set("Name", model.Name)
                .Set("Lastname", model.Lastname)
                .Set("Date", model.Date)
                .Set("Grades", model.Grades);

            mongoCollection.UpdateOne(filter, update);
        }
    }
}
