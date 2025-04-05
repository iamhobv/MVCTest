using lab2.Models;

namespace lab2.Repository
{
    public class DepartmentRepo : IDepartment
    {
        databaseContext context;
        public DepartmentRepo(databaseContext databaseContext)
        {
            //context = new databaseContext();
            context = databaseContext;
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(Department obj)
        {
            context.Departments.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department Department = GetById(id);

            context.Departments.Remove(Department);
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
