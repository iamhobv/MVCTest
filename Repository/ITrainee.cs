

using lab2.Models;

namespace lab2.Repository
{
    public interface ITrainee : IGeneralRepository<Trainee>
    {
        List<Trainee> TraineesWithDept();

    }
}
