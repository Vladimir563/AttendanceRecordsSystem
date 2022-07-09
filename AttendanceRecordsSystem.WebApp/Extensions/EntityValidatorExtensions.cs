using FluentValidation;
using FluentValidation.Results;
using System.Text;


namespace AttendanceRecordsSystem.WebApp.Extensions
{
    /// <summary>
    /// The extension method of the ASTON.STUDENT_ATTENDANCE_SYSTEM.BLL validator
    /// </summary>
    public static class EntityValidatorExtensions
    {
        /// <summary>
        /// This method validate entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static string ValidateEntity<T>(this IValidator<T> validator, T entity)
        {
            ValidationResult results = validator.Validate(entity);

            StringBuilder validationErrorsSb = new StringBuilder();

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    validationErrorsSb.AppendLine("Свойство " + failure.PropertyName + " не прошло валидацию. Ошибка: " + failure.ErrorMessage);
                }
            }

            return validationErrorsSb.ToString();
        }
    }
}
