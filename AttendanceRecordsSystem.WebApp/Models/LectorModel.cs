using System.Collections.Generic;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Models
{
    public class LectorModel : HumanModel
    {
        public List<LectionModel> Lections { get; set; }
    }
}
