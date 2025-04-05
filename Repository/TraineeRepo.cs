using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.Repository
{
    public class TraineeRepo : ITrainee
    {
        databaseContext context;
        public TraineeRepo(databaseContext databaseContext)
        {
            //context = new databaseContext();
            context = databaseContext;
        }
        public List<Trainee> GetAll()
        {
            return context.Trainees.ToList();
        }
        public Trainee GetById(int id)
        {
            return context.Trainees.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(Trainee obj)
        {
            context.Trainees.Add(obj);
        }
        public void Update(Trainee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Trainee trainee = GetById(id);

            context.Trainees.Remove(trainee);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Trainee> TraineesWithDept()
        {
            return context.Trainees.Include("Department").ToList();
        }
    }
}
