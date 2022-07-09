using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries;
using System;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        private readonly AttendanceRecordsSystemContext _db;

        private StudentsQueriesRepository _studentsQueriesRepository;
        private StudentsCommandsRepository _studentsCommandsRepository;

        private LectorsQueriesRepository _lectorsQueriesRepository;
        private LectorsCommandsRepository _lectorsCommandsRepository;

        private LectionsQueriesRepository _lectionsQueriesRepository;
        private LectionsCommandsRepository _lectionsCommandsRepository;

        private StudentsGroupsQueriesRepository _studentsGroupsQueriesRepository;
        private StudentsGroupsCommandsRepository _studentsGroupsCommandsRepository;

        public EFUnitOfWork(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        #region Queries

        public IQueriesRepository<Student> StudentsQueries
        {
            get
            {
                if (_studentsQueriesRepository == null)
                    _studentsQueriesRepository = new StudentsQueriesRepository(_db);
                return _studentsQueriesRepository;
            }
        }

        public IQueriesRepository<Lector> LectorsQueries
        {
            get
            {
                if (_lectorsQueriesRepository == null)
                    _lectorsQueriesRepository = new LectorsQueriesRepository(_db);
                return _lectorsQueriesRepository;
            }
        }

        public IQueriesRepository<Lection> LectionsQueries
        {
            get
            {
                if (_lectionsQueriesRepository == null)
                    _lectionsQueriesRepository = new LectionsQueriesRepository(_db);
                return _lectionsQueriesRepository;
            }
        }

        public IQueriesRepository<StudentsGroup> StudentsGroupsQueries
        {
            get
            {
                if (_studentsGroupsQueriesRepository == null)
                    _studentsGroupsQueriesRepository = new StudentsGroupsQueriesRepository(_db);
                return _studentsGroupsQueriesRepository;
            }
        }

        #endregion


        #region Commands

        public ICommandsRepository<Student> StudentsCommands
        {
            get
            {
                if (_studentsCommandsRepository == null)
                    _studentsCommandsRepository = new StudentsCommandsRepository(_db);
                return _studentsCommandsRepository;
            }
        }

        public ICommandsRepository<Lector> LectorsCommands
        {
            get
            {
                if (_lectorsCommandsRepository == null)
                    _lectorsCommandsRepository = new LectorsCommandsRepository(_db);
                return _lectorsCommandsRepository;
            }
        }

        public ICommandsRepository<Lection> LectionsCommands
        {
            get
            {
                if (_lectionsCommandsRepository == null)
                    _lectionsCommandsRepository = new LectionsCommandsRepository(_db);
                return _lectionsCommandsRepository;
            }
        }

        public ICommandsRepository<StudentsGroup> StudentsGroupsCommands
        {
            get
            {
                if (_studentsGroupsCommandsRepository == null)
                    _studentsGroupsCommandsRepository = new StudentsGroupsCommandsRepository(_db);
                return _studentsGroupsCommandsRepository;
            }
        }

        #endregion


        public void Save() => _db.SaveChanges();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }
    }
}
