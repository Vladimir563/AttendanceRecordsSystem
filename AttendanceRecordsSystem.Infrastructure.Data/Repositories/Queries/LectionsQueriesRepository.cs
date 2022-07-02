using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries
{
    public class LectionsQueriesRepository : IQueriesRepository<Lection>
    { 
        private AttendanceRecordsSystemContext _db;

        public LectionsQueriesRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public Lection Get(int id) => _db.Lections.Find(id);

        public IEnumerable<Lection> Find(Func<Lection, bool> predicate) => _db.Lections.Where(predicate).ToList();

        public IEnumerable<Lection> GetAll() => _db.Lections;
    }
}
