using lab2.Models;

namespace lab2.Repository
{
    public class CrsResultRepo : ICrsResult
    {
        databaseContext context;
        public CrsResultRepo(databaseContext databaseContext)
        {
            //context = new databaseContext();
            context = databaseContext;
        }
        public List<CrsResult> GetAll()
        {
            return context.CrsResults.ToList();
        }
        public CrsResult GetById(int id)
        {
            return context.CrsResults.FirstOrDefault(t => t.Id == id);
        }
        public void Insert(CrsResult obj)
        {
            context.CrsResults.Add(obj);
        }
        public void Update(CrsResult obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            CrsResult CrsResult = GetById(id);

            context.CrsResults.Remove(CrsResult);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<CrsResult> GetResultsByCrsId(int id)
        {
            return context.CrsResults.Where(i => i.CrsId == id).ToList();
        }

        public List<int> GetTrainessId()
        {
            return context.CrsResults.Select(t => t.TraineeID).ToList();
        }

        public int GetStudentResultInCrs(int CrsId, int StdId)
        {
            return context.CrsResults
                        .Where(g => g.CrsId == CrsId && g.TraineeID == StdId)
                        .Select(g => g.Degree)
                        .First();
        }

        public List<int> GetCrsIdByStdId(int StdId)
        {
            return context.CrsResults.Where(cr => cr.TraineeID == StdId).Select(cr => cr.CrsId).ToList();
        }
    }
}
