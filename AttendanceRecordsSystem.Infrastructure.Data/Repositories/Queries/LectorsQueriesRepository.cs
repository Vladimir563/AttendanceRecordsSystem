using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Queries
{
    public class LectorsQueriesRepository : IQueriesRepository<Lector>
    {
        private AttendanceRecordsSystemContext _db;

        public LectorsQueriesRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public Lector Get(int id) => _db.Lectors.Include(l => l.Lections).ToList().Find(s => s.Id == id);

        public IEnumerable<Lector> Find(Func<Lector, bool> predicate) => _db.Lectors.Include(l => l.Lections).Where(predicate).ToList();

        public IEnumerable<Lector> GetAll() => _db.Lectors.Include(l => l.Lections);
    }
}
