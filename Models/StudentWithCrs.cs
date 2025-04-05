using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Models
{
    public class StudentWithCrs
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string ImgUrl { get; set; }
        //public string Address { get; set; }
        //public int Grade { get; set; }

        //public int DeptId { get; set; }
        //public Department? Department { get; set; }
        //public List<CrsResult>? CrsResults { get; set; }







        //public string CrsName { get; set; }



        //public int Degree { get; set; }



        //public int MinDegree { get; set; }


        //public int Hours { get; set; }


        //[Remote("CheckCrsList", "Student", AdditionalFields = "CrsID")]
        public int StdID { get; set; }

        public int CrsID { get; set; }

    }
}
