using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using RestApi.Model.Interface;

namespace RestApi.Model
{
    public class Grade : IId<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public decimal GradeValue { get; set; }
        public string AddedDate { get; set; }

        public MongoDBRef CourseID { get; set; }
        public string CourseName { get; set; }

        public Grade()
        {
            if (Id.Equals(ObjectId.Empty))
                Id = ObjectId.GenerateNewId();

        }
    }
}