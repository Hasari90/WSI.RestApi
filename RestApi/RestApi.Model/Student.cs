using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace RestApi.Models
{
    [DataContract]
    public class Student
    {
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
        [DataMember]
        [BsonRequired]
        public List<Course> Courses { get; set; }
    }
}