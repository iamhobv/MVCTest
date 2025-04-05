using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Models
{
    public class CourseWithDeptInsVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        [Unique]
        public string Name { get; set; }
        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }
        [Required]
        [CkeckLessThanDegree]
        public int MinDegree { get; set; }


        [Remote("CheckHours", "Course", ErrorMessage = "hours must diviable by 3")]
        public int Hours { get; set; }

        public int DeptId { get; set; }

        public Department? Department { get; set; }
        public List<int>? Instructors { get; set; }
    }
}
