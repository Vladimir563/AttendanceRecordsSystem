using System.Collections.Generic;


namespace AttendanceRecordsSystem.WebApp.Models
{
    public class LectorModel : HumanModel
    {
        public List<LectionModel> Lections { get; set; }
    }
}
