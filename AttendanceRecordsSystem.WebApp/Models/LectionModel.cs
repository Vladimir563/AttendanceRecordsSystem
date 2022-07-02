using System;


namespace AttendanceRecordsSystem.WebApp.Models
{
    public class LectionModel
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
        public int LectorId { get; set; }
        public LectorModel Lector { get; set; }
    }
}
