using System;

namespace RestApi.Parameter
{
    public class StudentParameter
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? DateBefore { get; set; }
        public DateTime? DateAfter { get; set; }
    }
}
