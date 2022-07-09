using System.Collections.Generic;


namespace AttendanceRecordsSystem.Domain.Core
{
    public class Student : Human
    {
        public int StudentsGroupId { get; set; }
        public StudentsGroup Group { get; set; }
        public List<Lection> AttendedLections { get; set; }
    }
}
