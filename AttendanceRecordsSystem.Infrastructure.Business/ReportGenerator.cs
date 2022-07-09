using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AttendanceRecordsSystem.Infrastructure.Business
{
    public class ReportGenerator : IReportGenerator<Report>
    {
        private readonly IUnitOfWork _repositories;

        public ReportGenerator(IUnitOfWork repositories)
        {
            _repositories = repositories;
        }
        public List<Report> Generate(DateTime from, DateTime to, string lectionTittle, string groupName, string lectorName, string studentName) 
        {
            List<Report> reportsList = new List<Report>();

            var lections = _repositories.LectionsQueries.GetAll();

            if (lections is null) return null;

            // Применение фильтров
            if (from != DateTime.MinValue)
            {
                lections = lections.Where(l => l.Date >= from);
            }


            if (to != DateTime.MinValue)
            {
                lections = lections.Where(l => l.Date <= to);
            }


            if (string.IsNullOrEmpty(lectionTittle) == false)
            {
                lections = lections.Where(l => l.Tittle == lectionTittle);
            }


            if (string.IsNullOrEmpty(groupName) == false)
            {
                lections = lections.Where(l => l.Student.Group.Name == groupName);
            }


            if (string.IsNullOrEmpty(lectorName) == false)
            {
                lections = lections.Where(l => l.Lector.FirstName == lectorName);
            }


            if (string.IsNullOrEmpty(studentName) == false)
            {
                lections = lections.Where(l => l.Student.FirstName == studentName);
            }

            var filteredCollection = lections.GroupBy(l => l.Tittle).Select(l => new { title = l.Key, students = l.Select(p => p.Student).ToList() });


            foreach (var l in filteredCollection)
            {
                Report report = new Report()
                {
                    LectionTittle = l.title,
                    VisitingStudentsInfo = l.students.Select(s => $"Студент: {s.FirstName} {s.LastName}, оценка: {s.AttendedLections.Find(l => l.Id == l.Id).Mark}").ToList()
                };

                reportsList.Add(report);
            }

            return reportsList;
        }
    }
}
