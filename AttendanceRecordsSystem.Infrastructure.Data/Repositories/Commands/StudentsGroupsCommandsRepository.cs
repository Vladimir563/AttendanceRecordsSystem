using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands
{
    public class StudentsGroupsCommandsRepository : ICommandsRepository<StudentsGroup>
    {
        private AttendanceRecordsSystemContext _db;

        public StudentsGroupsCommandsRepository(AttendanceRecordsSystemContext context)
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

        public void Update(StudentsGroup newGroup, int id)
        {
            StudentsGroup group = _db.StudentsGroups.Find(id);

            group = newGroup;
        }
    }
}
