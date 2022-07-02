using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class LectorsRepository : IRepository<Lector>
    {
        private AttendanceRecordsSystemContext _db;

        public LectorsRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public void Create(Lector lector) => _db.Lectors.Add(lector);

        public void Delete(int id)
        {
            Lector lector = _db.Lectors.Find(id);
            if (lector != null)
                _db.Lectors.Remove(lector);
        }

        public IEnumerable<Lector> Find(Func<Lector, bool> predicate) => _db.Lectors.Where(predicate).ToList();

        public Lector Get(int id) => _db.Lectors.Find(id);

        public IEnumerable<Lector> GetAll() => _db.Lectors;

        public void Update(Lector newLector, int id) 
        {
            Lector lector = _db.Lectors.Find(id);

            lector = newLector;
        }
    }
}
