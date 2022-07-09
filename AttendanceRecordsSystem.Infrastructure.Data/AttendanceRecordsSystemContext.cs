//using AttendanceRecordsSystem.Domain.Core;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;


//namespace AttendanceRecordsSystem.Infrastructure.Data
//{
//    public class AttendanceRecordsSystemContext : DbContext
//    {
//        public DbSet<Student> Students { get; set; }
//        public DbSet<Lection> Lections { get; set; }
//        public DbSet<Lector> Lectors { get; set; }
//        public DbSet<StudentsGroup> StudentsGroups { get; set; }

//        private List<Student> _students;

//        private List<Lector> _lectors;

//        private List<Lection> _lections;

//        private List<StudentsGroup> _studentsGroups;

//        public AttendanceRecordsSystemContext() 
//        {

//        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AttendanceRecordsSystemDb;Username=postgres;Password=postgre");
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            Seed(modelBuilder);

//            modelBuilder.Entity<Lector>().Property(l => l.Id)
//                                            .UseIdentityAlwaysColumn()
//                                            .HasIdentityOptions(startValue: _lectors.Count + 1);

//            modelBuilder.Entity<Student>().Property(s => s.Id)
//                                            .UseIdentityAlwaysColumn()
//                                            .HasIdentityOptions(startValue: _students.Count + 1);

//            modelBuilder.Entity<Lection>().Property(le => le.Id)
//                                          .UseIdentityAlwaysColumn()
//                                          .HasIdentityOptions(startValue: _lections.Count + 1);

//            modelBuilder.Entity<StudentsGroup>().Property(sg => sg.Id)
//                                          .UseIdentityAlwaysColumn()
//                                          .HasIdentityOptions(startValue: _studentsGroups.Count + 1);
//        }


//        private void Seed(ModelBuilder modelBuilder)
//        {
//            _lectors = new List<Lector>()
//            {
//                new Lector() { Id = 1, FirstName = "Irina", Patronymic = "Petrovna", LastName = "Sakharova" },
//                new Lector() { Id = 2, FirstName = "Ivan", Patronymic = "Denisovich", LastName = "Lopatin" }
//            };
//            _lectors.ForEach(l => modelBuilder.Entity<Lector>().HasData(l));

//            _students = new List<Student>()
//            {
//                new Student() { Id = 1, FirstName = "Olga", LastName = "Laskina", GroupId = 1 },
//                new Student() { Id = 2, FirstName = "Tamara", LastName = "Komarova", GroupId = 1 },
//                new Student() { Id = 3, FirstName = "Vladimir", LastName = "Semenov", GroupId = 2 },
//                new Student() { Id = 4, FirstName = "Igor", LastName = "Onisiev", GroupId = 2 }
//            };
//            _students.ForEach(s => modelBuilder.Entity<Student>().HasData(s));

//            _lections = new List<Lection>()
//            {
//                new Lection() { Id = 1, Tittle = "Math", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 4, StudentId = 1 },
//                new Lection() { Id = 2, Tittle = "Math", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 2, StudentId = 2 },
//                new Lection() { Id = 3, Tittle = "Math", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 4, StudentId = 3 },
//                new Lection() { Id = 4, Tittle = "Math", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 5, StudentId = 4 },
//                new Lection() { Id = 5, Tittle = "Physics", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 5, StudentId = 1 },
//                new Lection() { Id = 6, Tittle = "Physics", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 5, StudentId = 2 },
//                new Lection() { Id = 7, Tittle = "Physics", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 3, StudentId = 3 },
//                new Lection() { Id = 8, Tittle = "Physics", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 3, StudentId = 4 },
//                new Lection() { Id = 9, Tittle = "Philosophy", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 3, StudentId = 1 },
//                new Lection() { Id = 10, Tittle = "Philosophy", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 4, StudentId = 2 },
//                new Lection() { Id = 11, Tittle = "Philosophy", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 4, StudentId = 3 },
//                new Lection() { Id = 12, Tittle = "Philosophy", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 4, StudentId = 4 },
//                new Lection() { Id = 13, Tittle = "Literature", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 4, StudentId = 1 },
//                new Lection() { Id = 14, Tittle = "Literature", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 3, StudentId = 2 },
//                new Lection() { Id = 15, Tittle = "Literature", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 5, StudentId = 3 },
//                new Lection() { Id = 16, Tittle = "Literature", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 2, StudentId = 4 }
//            };
//            _lections.ForEach(le => modelBuilder.Entity<Lection>().HasData(le));

//            _studentsGroups = new List<StudentsGroup>()
//            {
//                new StudentsGroup() { Id = 1, GroupName = "A1" },
//                new StudentsGroup() { Id = 2, GroupName = "A2" }
//            };
//            _studentsGroups.ForEach(sg => modelBuilder.Entity<StudentsGroup>().HasData(sg));
//        }
//    }
//}

using AttendanceRecordsSystem.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace AttendanceRecordsSystem.Infrastructure.Data
{
    public class AttendanceRecordsSystemContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lection> Lections { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<StudentsGroup> StudentsGroups { get; set; }

        private List<Student> _students;

        private List<Lector> _lectors;

        private List<Lection> _lections;

        private List<StudentsGroup> _studentsGroups;

        public AttendanceRecordsSystemContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=AttendanceRecordsSystemDb;Username=postgres;Password=postgre");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);

            modelBuilder.Entity<StudentsGroup>().Property(sg => sg.Id)
                              .UseIdentityAlwaysColumn()
                              .HasIdentityOptions(startValue: _studentsGroups.Count + 1);

            modelBuilder.Entity<Lector>().Property(l => l.Id)
                                            .UseIdentityAlwaysColumn()
                                            .HasIdentityOptions(startValue: _lectors.Count + 1);

            modelBuilder.Entity<Student>().Property(s => s.Id)
                                            .UseIdentityAlwaysColumn()
                                            .HasIdentityOptions(startValue: _students.Count + 1);

            modelBuilder.Entity<Lection>().Property(le => le.Id)
                                          .UseIdentityAlwaysColumn()
                                          .HasIdentityOptions(startValue: _lections.Count + 1);
        }


        private void Seed(ModelBuilder modelBuilder)
        {
            _studentsGroups = new List<StudentsGroup>()
            {
                new StudentsGroup() { Id = 1, Name = "А1" },
                new StudentsGroup() { Id = 2, Name = "А2" }
            };
            _studentsGroups.ForEach(sg => modelBuilder.Entity<StudentsGroup>().HasData(sg));

            _lectors = new List<Lector>()
            {
                new Lector() { Id = 1, FirstName = "Ирина", Patronymic = "Петровна", LastName = "Сахарова" },
                new Lector() { Id = 2, FirstName = "Иван", Patronymic = "Денисович", LastName = "Лопатин" }
            };
            _lectors.ForEach(l => modelBuilder.Entity<Lector>().HasData(l));

            _students = new List<Student>()
            {
                new Student() { Id = 1, FirstName = "Ольга", LastName = "Ласкина", StudentsGroupId = 1 },
                new Student() { Id = 2, FirstName = "Тамара", LastName = "Комарова", StudentsGroupId = 1 },
                new Student() { Id = 3, FirstName = "Владимир", LastName = "Семёнов", StudentsGroupId = 2 },
                new Student() { Id = 4, FirstName = "Игорь", LastName = "Онисьев", StudentsGroupId = 2 }
            };
            _students.ForEach(s => modelBuilder.Entity<Student>().HasData(s));

            _lections = new List<Lection>()
            {
                new Lection() { Id = 1, Tittle = "Математика", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 4, StudentId = 1 },
                new Lection() { Id = 2, Tittle = "Математика", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 4, StudentId = 3 },
                new Lection() { Id = 3, Tittle = "Математика", Date = new DateTime(2022, 3, 4), LectorId = 1, Mark = 5, StudentId = 4 },
                new Lection() { Id = 4, Tittle = "Физика", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 5, StudentId = 1 },
                new Lection() { Id = 5, Tittle = "Физика", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 5, StudentId = 2 },
                new Lection() { Id = 6, Tittle = "Физика", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 3, StudentId = 3 },
                new Lection() { Id = 7, Tittle = "Физика", Date = new DateTime(2022, 3, 6), LectorId = 1, Mark = 3, StudentId = 4 },
                new Lection() { Id = 8, Tittle = "Философия", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 3, StudentId = 1 },
                new Lection() { Id = 9, Tittle = "Философия", Date = new DateTime(2022, 3, 8), LectorId = 2, Mark = 4, StudentId = 4 },
                new Lection() { Id = 10, Tittle = "Литература", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 3, StudentId = 2 },
                new Lection() { Id = 11, Tittle = "Литература", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 5, StudentId = 3 },
                new Lection() { Id = 12, Tittle = "Литература", Date = new DateTime(2022, 3, 10), LectorId = 2, Mark = 2, StudentId = 4 }
            };
            _lections.ForEach(le => modelBuilder.Entity<Lection>().HasData(le));

        }
    }
}
