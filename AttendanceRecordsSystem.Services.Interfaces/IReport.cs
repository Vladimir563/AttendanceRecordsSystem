using System;


namespace AttendanceRecordsSystem.Services.Interfaces
{
    /// <summary>
    /// This inteface declare approach of getting a report of the students attendance
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Generate a report of the students attendance
        /// </summary>
        /// <param name="startDate">Start date of report</param>
        /// <param name="endDate">End date of report</param>
        /// <returns></returns>
        string GetReport(DateTime startDate, DateTime endDate);
    }
}
