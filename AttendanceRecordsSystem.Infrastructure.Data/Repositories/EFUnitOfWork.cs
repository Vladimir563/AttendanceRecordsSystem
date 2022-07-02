using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private AttendanceRecordsSystemContext _db;

        private StudentsRepository _studentsRepository;
        private LectorsRepository _lectorsRepository;
        private LectionsRepository _lectionsRepository;
        private StudentsGroupsRepository _studentsGroupsRepository;

        public EFUnitOfWork(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_studentsRepository == null)
                    _studentsRepository = new StudentsRepository(_db);
                return _studentsRepository;
            }
        }
        public IRepository<Lector> Lectors
        {
            get
            {
                if (_lectorsRepository == null)
                    _lectorsRepository = new LectorsRepository(_db);
                return _lectorsRepository;
            }
        }
        public IRepository<Lection> Lections
        {
            get
            {
                if (_lectionsRepository == null)
                    _lectionsRepository = new LectionsRepository(_db);
                return _lectionsRepository;
            }
        }
        public IRepository<StudentsGroup> StudentsGroups
        {
            get
            {
                if (_studentsGroupsRepository == null)
                    _studentsGroupsRepository = new StudentsGroupsRepository(_db);
                return _studentsGroupsRepository;
            }
        }

        public void Save() => _db.SaveChanges();

        private bool disposed = false;

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
