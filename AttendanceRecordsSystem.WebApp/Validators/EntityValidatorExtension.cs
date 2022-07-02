using FluentValidation;
using FluentValidation.Results;
using System.Text;


namespace AttendanceRecordsSystem.WebApp.Validators
{
    /// <summary>
    /// The extension method of the ASTON.STUDENT_ATTENDANCE_SYSTEM.BLL validator
    /// </summary>
    public static class EntityValidatorExtension
    {
        /// <summary>
        /// This method validate entity and throw the ValidationException if the validation result has failures
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator"></param>
        /// <param name="entity"></param>
        public static void ValidateEntity<T>(this IValidator<T> validator, T entity)
        {
            ValidationResult results = validator.Validate(entity);

            StringBuilder validationErrorsSb = new StringBuilder();

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    validationErrorsSb.AppendLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                throw new ValidationException(validationErrorsSb.ToString());
            }
        }
    }
}
