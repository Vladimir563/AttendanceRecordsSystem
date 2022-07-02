using AttendanceRecordsSystem.Domain.Core.Models;
using System;


namespace AttendanceRecordsSystem.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Lector> Lectors { get; }
        IRepository<Lection> Lections { get; }
        IRepository<StudentsGroup> StudentsGroups { get; }
        void Save();
    }
}
