using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


namespace AttendanceRecordsSystem.Authentication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }

        public List<Claim> Claims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, Username) };
            claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            return claims;
        }
    }
}
