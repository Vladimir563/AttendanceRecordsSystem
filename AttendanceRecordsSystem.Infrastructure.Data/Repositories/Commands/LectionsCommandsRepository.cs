using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands
{
    public class LectionsCommandsRepository : ICommandsRepository<Lection>
    {
        private readonly AttendanceRecordsSystemContext _db;

        public LectionsCommandsRepository(AttendanceRecordsSystemContext context)
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

        public void Update(Lection newLection, int id)
        {
            Lection lection = _db.Lections.Find(id);

            lection = newLection;
        }
    }
}
