using lab2.Models;

namespace lab2.Repository
{
    public interface IInstructor : IGeneralRepository<Instructor>
    {
        List<Instructor> GetInstructorsByCrsId(int id);

        List<Instructor> getInsWithDeptAndPaging(int skip, int take);
        int InstructorCount();

        Instructor GetInstractorDetails(int id);

    }
}
