using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;


namespace RestApi.Model
{
    [DataContract]
    public class Grade
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [DataMember]
        [BsonRequired]
        public int Id { get; set; }
        [DataMember]
        [BsonRequired]
        public double Mark { get; set; }
        [DataMember]
        [BsonRequired]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonRequired]
        public string CourseName { get; set; }
        [DataMember]
        [BsonRequired]
        public MongoDBRef Course { get; set; }
        [DataMember]
        [BsonIgnore]
        public List<Link> Links { get; set; }
    }
}