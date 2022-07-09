using AttendanceRecordsSystem.Authentication.Exceptions;
using AttendanceRecordsSystem.Authentication.Interfaces;
using AttendanceRecordsSystem.Authentication.Models;


namespace AttendanceRecordsSystem.Authentication.Services
{
    public class UserService
    {
        private readonly IUserQueriesRepository _queriesRepository;

        public UserService(IUserQueriesRepository queriesRepository)
        {
            _queriesRepository = queriesRepository;
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = _queriesRepository.Get(userCredentials.Username);
            bool isValid = user != null && AreValidCredentials(userCredentials, user);

            if (!isValid)
            {
                throw new InvalidCredentialsException();
            }
        }

        private static bool AreValidCredentials(UserCredentials userCredentials, User user)
        {
            return user.Username == userCredentials.Username &&
                   user.Password == userCredentials.Password;
        }
    }
}
