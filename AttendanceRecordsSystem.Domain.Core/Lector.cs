using System.Collections.Generic;


namespace AttendanceRecordsSystem.Domain.Core
{
    public class Lector : Human
    {
        public string Patronymic { get; set; }
        public List<Lection> Lections { get; set; }
    }
}
