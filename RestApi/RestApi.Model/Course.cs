using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RestApi.Model.Interface;

namespace RestApi.Model
{
    public class Course : IId<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LeadTeacher { get; set; }
        public string ECTS { get; set; }
    }
}