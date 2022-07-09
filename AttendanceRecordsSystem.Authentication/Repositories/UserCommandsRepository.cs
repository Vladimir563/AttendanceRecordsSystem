using AttendanceRecordsSystem.Authentication.EFCore;
using AttendanceRecordsSystem.Authentication.Interfaces;
using AttendanceRecordsSystem.Authentication.Models;


namespace AttendanceRecordsSystem.Authentication.Repositories
{
    public class UserCommandsRepository : IUserCommandsRepository
    {
        private readonly AuthenticationContext _db;

        public UserCommandsRepository(AuthenticationContext db)
        {
            _db = db;
        }
        public void Create(User user) => _db.Users.Add(user);

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
        }

        public void Update(User newUser, int id)
        {
            User user = _db.Users.Find(id);

            user = newUser;
        }
    }
}
