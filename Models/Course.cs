using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Models
{
    public class Course
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(int.MaxValue)]
        [MinLength(2)]
        [Unique]
        public string Name { get; set; }


        [Required]
        [Range(50, 100)]
        public int Degree { get; set; }


        [Required]
        [CkeckLessThanDegree]
        public int MinDegree { get; set; }

        [Remote("Course", "CheckHours", ErrorMessage = "hours must diviable by 3")]

        public int Hours { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public Department? Department { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<CrsResult>? CrsResults { get; set; }


    }
}
