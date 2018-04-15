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
    public class Grade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [BsonRequired]
        public double Mark { get; set; }
        [DataMember]
        [BsonRequired]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonRequired]
        public string CourseName { get; set; }
        [DataMember]
        [BsonIgnore]
        public Course Course { get; set; }
    }
}