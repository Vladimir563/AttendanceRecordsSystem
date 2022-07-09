using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.Infrastructure.Business;
using AttendanceRecordsSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;


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
        private readonly IReportGenerator<Report> _generator;
        private readonly IUnitOfWork _repositories;
        private readonly IMapper _mapper;

        public StudentsAttendanceReportController(IUnitOfWork repositories, IReportGenerator<Report> generator, IMapper mapper)
        {
            _generator = generator;
            _repositories = repositories;
            _mapper = mapper;
        }

        /// <summary>
        /// Получает отчёт по заданным критериям в JSON формате
        /// </summary>
        /// <param name="from">Дата от (формат: год/месяц/день)</param>
        /// <param name="to">Дата до (формат: год/месяц/день)</param>
        /// <param name="lectionTittle">Имя лекции</param>
        /// <param name="groupName">Имя группы студентов</param>
        /// <param name="lectorName">Имя лектора</param>
        /// <param name="studentName">Имя студента</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/jsonReport")]
        public IActionResult GetJsonReport(DateTime from, DateTime to, string lectionTittle, string groupName, string lectorName, string studentName)
        {
            return Ok(Json(_generator.Generate(from, to, lectionTittle, groupName, lectorName, studentName)));
        }


        /// <summary>
        /// Получает отчёт по заданным критериям в XML формате
        /// </summary>
        /// <param name="from">Дата от (формат: год/месяц/день)</param>
        /// <param name="to">Дата до (формат: год/месяц/день)</param>
        /// <param name="lectionTittle">Имя лекции</param>
        /// <param name="groupName">Имя группы студентов</param>
        /// <param name="lectorName">Имя лектора</param>
        /// <param name="studentName">Имя студента</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/xmlReport")]
        public IActionResult GetXmlReport(DateTime from, DateTime to, string lectionTittle, string groupName, string lectorName, string studentName)
        {
            List<Report> rList = _generator.Generate(from, to, lectionTittle, groupName, lectorName, studentName);

            using var stringwriter = new System.IO.StringWriter();
            
            var serializer = new XmlSerializer(rList.GetType());

            serializer.Serialize(stringwriter, rList);   

            return Ok(stringwriter.ToString());
        }
    }
}
