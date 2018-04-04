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
            Courses = new List<Course>();
        }


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
        public List<Course> Courses { get; set; }
    }
}