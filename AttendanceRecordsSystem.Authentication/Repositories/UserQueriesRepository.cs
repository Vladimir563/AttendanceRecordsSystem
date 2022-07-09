using AttendanceRecordsSystem.Authentication.EFCore;
using AttendanceRecordsSystem.Authentication.Interfaces;
using AttendanceRecordsSystem.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceRecordsSystem.Authentication.Repositories
{
    public class UserQueriesRepository : IUserQueriesRepository
    {
        private readonly AuthenticationContext _db;

        public UserQueriesRepository(AuthenticationContext db)
        {
            _db = db;
        }
        public IEnumerable<User> Find(Func<User, bool> predicate) => _db.Users.Where(predicate).ToList();

        public User Get(string name) => _db.Users.SingleOrDefault(u => u.Username.Equals(name));

        public IEnumerable<User> GetAll() => _db.Users;
    }
}
