using System;


namespace AttendanceRecordsSystem.Services.Interfaces
{
    /// <summary>
    /// This inteface declare approach of getting a report of the students attendance
    /// </summary>
    /// <typeparam name="T">type of the report which you wanna generate</typeparam>
    public interface IReport<T>
    {
        /// <summary>
        /// Generate a report of the students attendance
        /// </summary>
        /// <param name="startDate">Start date of report</param>
        /// <param name="endDate">End date of report</param>
        /// <returns></returns>
        T GetReport(DateTime startDate, DateTime endDate);
    }
}
