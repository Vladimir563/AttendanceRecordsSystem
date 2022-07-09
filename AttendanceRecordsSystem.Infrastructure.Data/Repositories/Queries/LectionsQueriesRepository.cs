using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries
{
    public class LectionsQueriesRepository : IQueriesRepository<Lection>
    { 
        private readonly AttendanceRecordsSystemContext _db;

        public LectionsQueriesRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public Lection Get(int id) => _db.Lections.Include(l => l.Student).Include(s => s.Lector).ToList().Find(l => l.Id == id);

        public IEnumerable<Lection> Find(Func<Lection, bool> predicate) => _db.Lections.Include(l => l.Student).Include(s => s.Lector).Where(predicate).ToList();

        public IEnumerable<Lection> GetAll() => _db.Lections.Include(l => l.Student).Include(s => s.Lector);
    }
}
