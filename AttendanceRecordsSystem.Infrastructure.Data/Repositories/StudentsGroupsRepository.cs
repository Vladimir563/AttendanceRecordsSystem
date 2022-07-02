using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class StudentsGroupsRepository : IRepository<StudentsGroup>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsGroupsRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public void Create(StudentsGroup groups) => _db.StudentsGroups.Add(groups);

        public void Delete(int id)
        {
            StudentsGroup group = _db.StudentsGroups.Find(id);
            if (group != null)
                _db.StudentsGroups.Remove(group);
        }

        public IEnumerable<StudentsGroup> Find(Func<StudentsGroup, bool> predicate) => _db.StudentsGroups.Where(predicate).ToList();

        public StudentsGroup Get(int id) => _db.StudentsGroups.Find(id);

        public IEnumerable<StudentsGroup> GetAll() => _db.StudentsGroups;

        public void Update(StudentsGroup newGroup, int id) 
        {
            StudentsGroup group = _db.StudentsGroups.Find(id);

            group = newGroup;
        }
    }
}
