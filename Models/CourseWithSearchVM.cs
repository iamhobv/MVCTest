using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class CourseWithSearchVM
    {
        public List<Course>? Courses { get; set; }

        public string SearchText { get; set; }
    }
}
