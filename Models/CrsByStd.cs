using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class CrsByStd
    {
        [Key]
        public string Name { get; set; }
        public string CrsName { get; set; }
    }
}
