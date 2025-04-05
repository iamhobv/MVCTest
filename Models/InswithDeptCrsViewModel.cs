using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Models
{
    public class InswithDeptCrsViewModel
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Address { get; set; }

        public int DeptId { get; set; }


        //[Remote("CrsFilter", "Instructor", AdditionalFields = "DeptId")]
        public int CrsId { get; set; }

        public List<Department>? Departments;

        public List<Course>? Courses;

    }
}
