using System.Collections.Generic;


namespace AttendanceRecordsSystem.WebApp.Models 
{ 
    public class StudentModel : HumanModel
    {
        public int GroupId { get; set; }
        public StudentsGroupModel Group { get; set; }
        public List<LectionModel> AttendedLections { get; set; }
    }
}
