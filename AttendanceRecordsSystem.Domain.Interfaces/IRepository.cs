using System;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item, int id);
        void Delete(int id);
    }
}
