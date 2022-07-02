using System;


namespace AttendanceRecordsSystem.Domain.Core
{
    public class Lection
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LectorId { get; set; }
        public Lector Lector { get; set; }
    }
}
