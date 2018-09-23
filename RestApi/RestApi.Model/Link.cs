using System.Runtime.Serialization;

namespace RestApi.Model
{
    [DataContract]
    public class Link
    {
        [DataMember]
        public string Rel { get; set; }
        [DataMember]
        public string Href { get; set; }
    }
}
