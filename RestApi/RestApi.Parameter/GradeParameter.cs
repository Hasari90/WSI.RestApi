using System;

namespace RestApi.Parameter
{
    public class GradeParameter
    {
        public double? LowerGrades { get; set; }
        public double? Value { get; set; }
        public double? HigherGrades { get; set; }
        public DateTime? Created { get; set; }
    }
}
