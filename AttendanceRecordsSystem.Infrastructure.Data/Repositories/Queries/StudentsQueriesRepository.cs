using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries
{
    public class StudentsQueriesRepository : IQueriesRepository<Student>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsQueriesRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public Student Get(int id) => _db.Students.Find(id);

        public IEnumerable<Student> Find(Func<Student, bool> predicate) => _db.Students.Where(predicate).ToList();

        public IEnumerable<Student> GetAll() => _db.Students;
    }
}
