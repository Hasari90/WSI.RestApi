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
    public class Course
    {
        [DataMember]
        [BsonRequired]
        public string Name { get; set; }
        [DataMember]
        [BsonRequired]
        public string Teacher { get; set; }
    }
}