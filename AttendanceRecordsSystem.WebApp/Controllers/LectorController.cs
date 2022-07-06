using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.WebApp.Models;
using AttendanceRecordsSystem.WebApp.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AttendanceRecordsSystem.WebApp.Controllers
{
    /// <summary>
    /// Контроллер для манипуляций с моделью лектора
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Route("api/[controller]")]
    [Route("api/[controller]")]
    public class LectorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IQueriesRepository<Lector> _lectorsQueriesRepository;
        private readonly ICommandsRepository<Lector> _lectorsCommandsRepository;
        private readonly IValidator<Lector> _validator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="lectorsQueriesRepository"></param>
        /// <param name="lectorsCommandsRepository"></param>
        /// <param name="validator"></param>
         public LectorController(IMapper mapper, IQueriesRepository<Lector> lectorsQueriesRepository, 
             ICommandsRepository<Lector> lectorsCommandsRepository, IValidator<Lector> validator)
        {
            _lectorsQueriesRepository = lectorsQueriesRepository;
            _lectorsCommandsRepository = lectorsCommandsRepository;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// Добавление нового лектора
        /// </summary>
        /// <param name="fName">Имя</param>
        /// <param name="lName">Фамилия</param>
        /// <param name="patr">Отчество</param>
        /// <param name="lections">Список лекций</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateLector(string fName, string lName, string patr, IEnumerable<Lection> lections)
        {
            Lector lector = new Lector()
            {
                FirstName = fName,
                LastName = lName,
                Patronymic = patr,
                Lections = lections.ToList()
            };

            string validationErrors =_validator.ValidateEntity(lector);

            if (string.IsNullOrEmpty(validationErrors) == false) 
            {
                return BadRequest($"{ValidationMessageGenerator.GetValidateFailureMessage()}: \n{validationErrors}");
            }

            _lectorsCommandsRepository.Create(lector);

            LectorModel lectorModel = _mapper.Map<LectorModel>(lector);

            return Ok($"{ValidationMessageGenerator.GetCreateSuccessMessage("Лектор")} \n{Json(lectorModel)}");
        }

        /// <summary>
        /// Обновление лектора
        /// </summary>
        /// <param name="newLector">Новый лектор</param>
        /// <param name="id">Id лектора для обновления</param>
        [HttpPut]
        public IActionResult UpdateLector(Lector newLector, int id)
        {
            Lector lector = _lectorsQueriesRepository.Get(id);

            if (lector is null) 
            {
                return NotFound(ValidationMessageGenerator.GetFindFailureMessage("Лектор"));
            }

            lector = newLector;

            return Ok($"{ValidationMessageGenerator.GetUpdateSuccessMessage("Лектор")} \n{Json(lector)}");
        }

        /// <summary>
        /// Удаление лектора
        /// </summary>
        /// <param name="id">Id лектора для удаления</param>
        [HttpDelete]
        public IActionResult DeleteLector(int id)
        {
            Lector lector = _lectorsQueriesRepository.Get(id);

            if (lector is null) 
            {
                return NotFound(ValidationMessageGenerator.GetDeleteFailureMessage("Лектор"));
            }

            return Ok(ValidationMessageGenerator.GetDeleteSuccessMessage("Лектор"));
        }

        /// <summary>
        /// Получение лектора по id
        /// </summary>
        /// <param name="id">Id лектора</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetLector(int id) 
        {
            Lector lector = _lectorsQueriesRepository.Get(id);

            if (lector is null)
            {
                return NotFound(ValidationMessageGenerator.GetFindFailureMessage("Лектор"));
            }

            return Ok(Json(_mapper.Map<LectorModel>(_lectorsQueriesRepository.Get(id))));
        } 
    }
}
