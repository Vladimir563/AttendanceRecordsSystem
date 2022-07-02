using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories
{
    public class StudentsRepository : IRepository<Student>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsRepository(AttendanceRecordsSystemContext context)
        {
            _db = context;
        }

        public void Create(Student stud) => _db.Students.Add(stud);

        public void Delete(int id)
        {
            Student stud = _db.Students.Find(id);
            if (stud != null)
                _db.Students.Remove(stud);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate) => _db.Students.Where(predicate).ToList();

        public Student Get(int id) => _db.Students.Find(id);

        public IEnumerable<Student> GetAll() => _db.Students;

        public void Update(Student newStud, int id) 
        {
            Student stud = _db.Students.Find(id);

            stud = newStud;
        }
    }
}
