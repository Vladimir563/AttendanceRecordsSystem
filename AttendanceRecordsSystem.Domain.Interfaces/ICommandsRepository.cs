

namespace AttendanceRecordsSystem.Domain.Interfaces
{
    public interface ICommandsRepository<T> where T : class
    {
        void Create(T item);
        void Update(T item, int id);
        void Delete(int id);
    }
}
