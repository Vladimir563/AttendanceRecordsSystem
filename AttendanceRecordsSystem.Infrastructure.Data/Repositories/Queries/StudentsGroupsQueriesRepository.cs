using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries
{
    public class StudentsGroupsQueriesRepository : IQueriesRepository<StudentsGroup>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsGroupsQueriesRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public StudentsGroup Get(int id) => _db.StudentsGroups.Include(s => s.Students).ToList().Find(s => s.Id == id);

        public IEnumerable<StudentsGroup> Find(Func<StudentsGroup, bool> predicate) => _db.StudentsGroups.Include(s => s.Students).Where(predicate).ToList();

        public IEnumerable<StudentsGroup> GetAll() => _db.StudentsGroups.Include(s => s.Students);
    }
}
