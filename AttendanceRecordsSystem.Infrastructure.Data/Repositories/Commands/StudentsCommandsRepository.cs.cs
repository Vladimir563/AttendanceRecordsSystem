using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands
{
    public class StudentsCommandsRepository : ICommandsRepository<Student>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsCommandsRepository(AttendanceRecordsSystemContext context)
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

        public void Update(Student newStud, int id)
        {
            Student stud = _db.Students.Find(id);

            stud = newStud;
        }
    }
}
