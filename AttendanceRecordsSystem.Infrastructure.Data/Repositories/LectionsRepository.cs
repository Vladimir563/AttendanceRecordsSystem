using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class LectionsRepository : IRepository<Lection>
    {
        private AttendanceRecordsSystemContext _db;

        public LectionsRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public void Create(Lection lect) => _db.Lections.Add(lect);

        public void Delete(int id)
        {
            Lection lect = _db.Lections.Find(id);
            if (lect != null)
                _db.Lections.Remove(lect);
        }

        public IEnumerable<Lection> Find(Func<Lection, bool> predicate) => _db.Lections.Where(predicate).ToList();

        public Lection Get(int id) => _db.Lections.Find(id);

        public IEnumerable<Lection> GetAll() => _db.Lections;

        public void Update(Lection newLection, int id) 
        {
            Lection lection = _db.Lections.Find(id);

            lection = newLection;
        }
    }
}
