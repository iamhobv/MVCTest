using System.Diagnostics.Metrics;
using lab2.Models;

namespace lab2.Repository
{
    public interface ICourse : IGeneralRepository<Course>
    {
        List<Course> CoursesDeptIns();
        List<Course> GetByNameWithDeptIns(string name);
        List<Course> GetCrsByDeptID(int id);
    }
}
