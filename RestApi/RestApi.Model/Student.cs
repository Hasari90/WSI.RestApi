using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }
        [BsonRequired]
        public List<Grade> Grades { get; set; }
        [DataMember]
        [BsonIgnore]
        public List<Link> Links { get; set; }
    }
}