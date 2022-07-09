using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Data.Repositories;
using AttendanceRecordsSystem.WebApp.Models;
using AttendanceRecordsSystem.WebApp.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Controllers
{
    /// <summary>
    /// Контроллер для получения отчётов
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class StudentsAttendanceReportController : Controller
    {
        private readonly IUnitOfWork _repositories;
        private readonly IMapper _mapper;

        public StudentsAttendanceReportController(IUnitOfWork repositories, IMapper mapper)
        {
            _repositories = repositories;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает отчёт по заданным критериям
        /// </summary>
        /// <param name="from">Дата от (формат: год/месяц/день)</param>
        /// <param name="to">Дата до (формат: год/месяц/день)</param>
        /// <param name="lectionTittle">Имя лекции</param>
        /// <param name="groupName">Имя группы студентов</param>
        /// <param name="lectorName">Имя лектора</param>
        /// <param name="studentName">Имя студента</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetReport(DateTime from, DateTime to, string lectionTittle, string groupName, string lectorName, string studentName)
        {
            StringBuilder reportDescription = new StringBuilder("Отчёт посещаемости студентов:\n");

            DateTimeFormatInfo info = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat;

            var lections = _repositories.LectionsQueries.GetAll();

            if (lections is null) return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Список лекций"));

            // Применение фильтров
            if (from != DateTime.MinValue) 
            {
                reportDescription.AppendLine($"- от {from.Day} ({info.MonthNames[from.Month].ToLower()}) {from.Year} года");
                lections = lections.Where(l => l.Date >= from);
            }


            if (to != DateTime.MinValue) 
            {
                reportDescription.AppendLine($"- по {to.Day} ({info.MonthNames[to.Month].ToLower()}) {to.Year} года");
                lections = lections.Where(l => l.Date <= to);
            }


            if (string.IsNullOrEmpty(lectionTittle) == false) 
            {
                reportDescription.AppendLine($"- для лекций \"{lectionTittle}\"");
                lections = lections.Where(l => l.Tittle == lectionTittle);
            }


            if (string.IsNullOrEmpty(groupName) == false) 
            {
                reportDescription.AppendLine($"- для студентов из группы \"{groupName}\"");
                lections = lections.Where(l => l.Student.Group.Name == groupName);
            }


            if (string.IsNullOrEmpty(lectorName) == false) 
            {
                reportDescription.AppendLine($"- проведённых лектором \"{lectorName}\"");
                lections = lections.Where(l => l.Lector.FirstName == lectorName);
            }


            if (string.IsNullOrEmpty(studentName) == false) 
            {
                reportDescription.AppendLine($"- для студента \"{studentName}\"");
                lections = lections.Where(l => l.Student.FirstName == studentName);
            }
                

            StringBuilder sb = new StringBuilder(reportDescription.ToString() + "\n");

            var filteredCollection = lections.GroupBy(l => l.Tittle).Select(l => new {title = l.Key, students = l.Select(p => p.Student).ToList()});

            foreach (var lection in filteredCollection)
            {
                sb.AppendLine($"{lection.title}:");

                foreach (var s in lection.students)
                {
                    var studLection = s.AttendedLections.Find(o => o.Tittle == lection.title);
                    sb.AppendLine($"Лектор: {_mapper.Map<LectorModel>(studLection.Lector).FullName}, " +
                        $"студент: {s.FirstName} {s.LastName} (группа {s.Group.Name}), оценка: {studLection.Mark}");
                }

                sb.AppendLine("\n");
            }

            return Ok(sb.ToString());
        }
    }
}
