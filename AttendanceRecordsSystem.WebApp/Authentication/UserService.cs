﻿

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Authentication
{
    public class UserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void ValidateCredentials(UserCredentials userCredentials)
        {
            User user = userRepository.GetUser(userCredentials.Username);
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
