using System.Collections.Generic;


namespace AttendanceRecordsSystem.WebApp.Models
{
    /// <summary>
    /// Модель данных лектора
    /// </summary>
    public class LectorModel : HumanModel
    {
        /// <summary>
        /// Список лекций которые проводит лектор
        /// </summary>
        public List<LectionModel> Lections { get; set; }
    }
}
