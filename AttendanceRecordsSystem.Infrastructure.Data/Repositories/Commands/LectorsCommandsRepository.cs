using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;


namespace AttendanceRecordsSystem.Infrastructure.Data.Repositories.Commands
{
    public class LectorsCommandsRepository : ICommandsRepository<Lector>
    {
        private AttendanceRecordsSystemContext _db;

        public LectorsCommandsRepository(AttendanceRecordsSystemContext context)
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

        public void Update(Lector newLector, int id)
        {
            Lector lector = _db.Lectors.Find(id);

            lector = newLector;
        }
    }
}
