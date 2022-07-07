using System.Collections.Generic;
using System.Linq;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Authentication
{
    public class UserRepository
    {
        private readonly IEnumerable<User> users;

        public UserRepository()
        {
            users = new List<User>
            {
                new User
                {
                    Username = "vladimir35",
                    Password = "123321",
                    Roles = new []{"User"}
                },
                new User
                {
                    Username = "veta28",
                    Password = "111",
                    Roles = new []{"User", "Admin"}
                }
            };
        }

        public User GetUser(string username)
        {
            return users.SingleOrDefault(u => u.Username.Equals(username));
        }
    }
}
