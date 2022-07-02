using AttendanceRecordsSystem.Domain.Core;
using System;


namespace AttendanceRecordsSystem.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQueriesRepository<Student> StudentsQueries { get; }
        ICommandsRepository<Student> StudentsCommands { get; }

        IQueriesRepository<Lector> LectorsQueries { get; }
        ICommandsRepository<Lector> LectorsCommands { get; }

        IQueriesRepository<Lection> LectionsQueries { get; }
        ICommandsRepository<Lection> LectionsCommands { get; }

        IQueriesRepository<StudentsGroup> StudentsGroupsQueries { get; }
        ICommandsRepository<StudentsGroup> StudentsGroupsCommands { get; }

        void Save();
    }
}
