using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public string Address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department? Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }

    }
}
