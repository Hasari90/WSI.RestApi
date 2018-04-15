using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace RestApi.Model
{
    [DataContract]
    public class Student
    {
        public Student()
        {
            Grades = new List<Grade>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [DataMember]
        [BsonRequired]
        public int Index { get; set; }
        [DataMember]
        [BsonRequired]
        public string Name { get; set; }
        [DataMember]
        [BsonRequired]
        public string Lastname { get; set; }
        [DataMember]
        [BsonRequired]
        public DateTime Date { get; set; }
        [BsonRequired]
        public List<Grade> Grades { get; set; }
    }
}