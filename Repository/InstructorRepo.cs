using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.Repository
{
    public class InstructorRepo : IInstructor
    {
        databaseContext context;
        public InstructorRepo(databaseContext databaseContext)
        {
            //context = new databaseContext();
            context = databaseContext;
        }
        public List<Instructor> GetAll()
        {
            return context.Instructors.ToList();
        }
        public Instructor GetById(int id)
        {
            return context.Instructors.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(Instructor obj)
        {
            context.Instructors.Add(obj);
        }
        public void Update(Instructor obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Instructor Instructor = GetById(id);

            context.Instructors.Remove(Instructor);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Instructor> GetInstructorsByCrsId(int id)
        {
            return context.Instructors.Where(i => i.CrsId == id).ToList();
        }

        public List<Instructor> getInsWithDeptAndPaging(int skip, int take)
        {
            return context.Instructors.Include("Department").Skip(skip).Take(take).ToList();
        }

        public int InstructorCount()
        {
            return context.Instructors.Count();
        }

        public Instructor GetInstractorDetails(int id)
        {
            return context.Instructors.Include("Department").Include("Course").FirstOrDefault(i => i.Id == id);
        }
    }
}
