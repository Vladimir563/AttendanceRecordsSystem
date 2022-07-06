
#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Validators
{
    public static class ValidationMessageGenerator
    {
        public static string GetCreateSuccessMessage(string entityName) => $"{entityName} успешно создан";

        public static string GetCreateFailureMessage(string entityName) => $"{entityName} не был создан";

        public static string GetFindFailureMessage(string entityName) => $"{entityName} не найден";

        public static string GetUpdateSuccessMessage(string entityName) => $"{entityName} успешно обновлён";

        public static string GetDeleteSuccessMessage(string entityName) => $"{entityName} успешно удалён";

        public static string GetUpdateFailureMessage(string entityName) => $"{entityName} не был обновлён";

        public static string GetDeleteFailureMessage(string entityName) => $"{entityName} не был удалён";

        public static string GetValidateFailureMessage() => $"Введены некорректные данные";
        
    }
}
