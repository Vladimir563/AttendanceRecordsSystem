

namespace AttendanceRecordsSystem.Services
{
    /// <summary>
    /// This inteface declare approach of getting a report of the students attendance
    /// </summary>
    public interface IReport
    {
        string GetReport(params object[] criteria);
    }
}
