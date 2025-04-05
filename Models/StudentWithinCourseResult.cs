using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace lab2.Models
{
    public class StudentWithinCourseResult
    {

        public string StdName { get; set; }
        public string CrsName { get; set; }
        public int StdGrade { get; set; }
        public int CourseFullGrade { set; get; }
        public int CourseMinGrade { set; get; }
        public string StdColor { get; set; }
        public string statusString { get; set; }
        public bool status { get; set; }

    }
}
