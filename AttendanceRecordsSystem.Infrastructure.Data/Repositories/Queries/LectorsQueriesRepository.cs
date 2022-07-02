using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
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

        public Lector Get(int id) => _db.Lectors.Find(id);

        public IEnumerable<Lector> Find(Func<Lector, bool> predicate) => _db.Lectors.Where(predicate).ToList();

        public IEnumerable<Lector> GetAll() => _db.Lectors;
    }
}
