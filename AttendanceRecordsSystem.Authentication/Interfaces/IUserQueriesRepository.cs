using AttendanceRecordsSystem.Authentication.Models;
using System;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Authentication.Interfaces
{
    public interface IUserQueriesRepository
    {
        User Get(string name);
        IEnumerable<User> Find(Func<User, bool> predicate);
        IEnumerable<User> GetAll();
    }
}
