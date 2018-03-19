using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestApi.Models
{
    [DataContract]
    public class Grade
    {
        [DataMember]
        public double mark { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public int indexStudent { get; set; }
    }
}