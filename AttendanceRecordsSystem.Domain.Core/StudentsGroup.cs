using System.Collections.Generic;


namespace AttendanceRecordsSystem.Domain.Core
{
    public class StudentsGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
