using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestApi.Model
{
    [DataContract]
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [DataMember]
        [BsonRequired]
        public string Name { get; set; }
        [DataMember]
        [BsonRequired]
        public string Teacher { get; set; }
        [DataMember]
        [BsonRequired]
        public int ECTS { get; set; }
        [DataMember]
        [BsonIgnore]
        public List<Link> Links { get; set; }
        
    }
}