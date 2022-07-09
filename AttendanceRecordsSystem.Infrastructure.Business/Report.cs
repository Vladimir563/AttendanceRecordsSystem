using AttendanceRecordsSystem.Domain.Core;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Infrastructure.Business
{
    public class Report
    {
        public string LectionTittle { get; set; }

        public List<string> VisitingStudentsInfo { get; set; }
    }
}
