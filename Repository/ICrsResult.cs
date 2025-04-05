using lab2.Models;

namespace lab2.Repository
{
    public interface ICrsResult : IGeneralRepository<CrsResult>
    {
        List<CrsResult> GetResultsByCrsId(int id);
        List<int> GetTrainessId();
        int GetStudentResultInCrs(int CrsId, int StdId);
        List<int> GetCrsIdByStdId(int StdId);
    }
}
