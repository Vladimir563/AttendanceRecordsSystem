using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Authentication
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public IEnumerable<Claim> Claims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, Username) };
            claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            return claims;
        }
    }
}
