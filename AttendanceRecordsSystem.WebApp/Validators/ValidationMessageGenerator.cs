

namespace AttendanceRecordsSystem.WebApp.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValidationMessageGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetCreateSuccessMessage(string entityName) => $"{entityName} успешно создан";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetCreateFailureMessage(string entityName) => $"{entityName} не был создан";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetFindFailureMessage(string entityName) => $"{entityName} не найден";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetUpdateSuccessMessage(string entityName) => $"{entityName} успешно обновлён";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetDeleteSuccessMessage(string entityName) => $"{entityName} успешно удалён";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetUpdateFailureMessage(string entityName) => $"{entityName} не был обновлён";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public static string GetDeleteFailureMessage(string entityName) => $"{entityName} не был удалён";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetValidateFailureMessage() => $"Введены некорректные данные";
        
    }
}
