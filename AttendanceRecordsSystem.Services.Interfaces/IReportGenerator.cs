using System;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Services
{
    /// <summary>
    /// This inteface declare approach of getting a report of the students attendance
    /// </summary>
    public interface IReportGenerator<T>
    {
        List<T> Generate(DateTime from, DateTime to, string lectionTittle, string groupName, string lectorName, string studentName);
    }
}
