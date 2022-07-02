using System;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Domain.Interfaces
{
    public interface IQueriesRepository<T> where T : class
    {
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        IEnumerable<T> GetAll();
    }
}
