using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.Repository
{
    public class CourseRepo : ICourse
    {
        databaseContext context;
        public CourseRepo(databaseContext databaseContext)
        {
            //context = new databaseContext();
            context = databaseContext;
        }
        public List<Course> GetAll()
        {
            return context.Courses.ToList();
        }
        public Course GetById(int id)
        {
            return context.Courses.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(Course obj)
        {
            context.Courses.Add(obj);
        }
        public void Update(Course obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Course Course = GetById(id);

            context.Courses.Remove(Course);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Course> CoursesDeptIns()
        {
            return context.Courses.Include("Department").Include("Instructors").ToList();
        }

        public List<Course> GetByNameWithDeptIns(string name)
        {
            return context.Courses.Where(c => c.Name.Contains(name)).Include("Department").Include("Instructors").ToList();
        }

        public List<Course> GetCrsByDeptID(int id)
        {
            return context.Courses.Where(c => c.DeptId == id).ToList();
        }
    }
}
