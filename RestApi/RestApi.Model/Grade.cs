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
        [DataMember]
        [BsonRequired]
        public double Mark { get; set; }
        [DataMember]
        [BsonRequired]
        public DateTime Date { get; set; }
        [DataMember]
        [BsonRequired]
        public int IndexStudent { get; set; }
    }
}