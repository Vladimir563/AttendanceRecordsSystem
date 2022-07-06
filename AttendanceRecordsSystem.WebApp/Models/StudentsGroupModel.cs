using System.Collections.Generic;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Models
{
    public class StudentsGroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public List<StudentModel> Students { get; set; }
    }
}
