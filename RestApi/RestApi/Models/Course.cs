using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestApi.Models
{
    [DataContract]
    public class Course
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string teacher { get; set; }
        [DataMember]
        public Grade[] grades { get; set; }
    }
}