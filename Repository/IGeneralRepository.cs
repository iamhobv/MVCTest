using lab2.Models;

namespace lab2.Repository
{
    public interface IGeneralRepository<T>
    {

        List<T> GetAll();

        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);

        void Save();
    }
}
