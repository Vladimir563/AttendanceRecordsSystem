using AttendanceRecordsSystem.Authentication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Authentication.EFCore
{
    public class AuthenticationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        private List<User> _users;

        private List<Role> _roles;

        public AuthenticationContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AttendanceRecordsSystemAuthenticationDb;Username=postgres;Password=postgre");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);

            modelBuilder.Entity<User>().Property(u => u.Id)
                                            .UseIdentityAlwaysColumn()
                                            .HasIdentityOptions(startValue: _users.Count + 1);

            modelBuilder.Entity<Role>().Property(u => u.Id)
                                            .UseIdentityAlwaysColumn()
                                            .HasIdentityOptions(startValue: _roles.Count + 1);
        }


        private void Seed(ModelBuilder modelBuilder)
        {
            _users = new List<User>()
            {
                new User() { Id = 1, Username = "vladimir35", Password = "123321" },
                new User() { Id = 2, Username = "veta28", Password = "111" }
            };
            _users.ForEach(u => modelBuilder.Entity<User>().HasData(u));


            _roles = new List<Role>()
            {
                new Role() { Id = 1, Name = "User", UserId = 1 },
                new Role() { Id = 2, Name = "User", UserId = 2 },
                new Role() { Id = 3, Name = "Admin", UserId = 2 }
            };
            _roles.ForEach(u => modelBuilder.Entity<Role>().HasData(u));
        }
    }
}
