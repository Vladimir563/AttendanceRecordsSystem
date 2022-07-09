using AttendanceRecordsSystem.Authentication.Models;


namespace AttendanceRecordsSystem.Authentication.Interfaces
{
    public interface IUserCommandsRepository
    {
        void Create(User user);
        void Update(User user, int id);
        void Delete(int id);
    }
}
