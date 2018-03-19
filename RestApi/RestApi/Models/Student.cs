using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestApi.Models
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public int index { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string lastname { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public List<Course> courses { get; set; }
    }
}