using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.WebApp.Extensions;
using AttendanceRecordsSystem.WebApp.Models;
using AttendanceRecordsSystem.WebApp.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace AttendanceRecordsSystem.WebApp.Controllers
{
    /// <summary>
    /// Контроллер для манипуляций с моделью лекции
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class LectionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repository;
        private readonly IValidator<Lection> _validator;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="validator"></param>
        public LectionController(IMapper mapper, IUnitOfWork repository, IValidator<Lection> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }


        /// <summary>
        /// Добавление новой лекции
        /// </summary>
        /// <param name="title"></param>
        /// <param name="date"></param>
        /// <param name="lectorId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateLection(string title, DateTime date, int lectorId)
        {
            Lection lection = new Lection()
            {
                Tittle = title,
                Date = date,
                LectorId = lectorId
            };

            string validationErrors = _validator.ValidateEntity(lection);

            if (string.IsNullOrEmpty(validationErrors) == false)
            {
                return BadRequest($"{ValidationMessageGenerator.GetValidateFailureMessage()}: \n{validationErrors}");
            }

            Lector lector = _repository.LectorsQueries.Get(lectorId);

            if (lector is null) return NotFound($"{ValidationMessageGenerator.GetNotFoundMessage("Лектор")} \n{Json(lector)}");

            lection.Lector = lector;

            _repository.LectionsCommands.Create(lection);

            LectionModel lectionModel = _mapper.Map<LectionModel>(lection);

            return Ok($"{ValidationMessageGenerator.GetCreateSuccessMessage("Лекция")} \n{Json(lectionModel)}");
        }

        /// <summary>
        /// Обновление лекции
        /// </summary>
        /// <param name="newLection">Новая лекция</param>
        /// <param name="id">Id лекции для обновления</param>
        [HttpPut]
        public IActionResult UpdateLection(Lection newLection, int id)
        {
            Lection lection = _repository.LectionsQueries.Get(id);

            if (lection is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Лекция"));
            }

            _repository.LectionsCommands.Update(newLection, id);

            return Ok($"{ValidationMessageGenerator.GetUpdateSuccessMessage("Лекция")} \n{Json(newLection)}");
        }

        /// <summary>
        /// Удаление лекции
        /// </summary>
        /// <param name="id">Id лекции для удаления</param>
        [HttpDelete]
        public IActionResult DeleteLection(int id)
        {
            Lection lection = _repository.LectionsQueries.Get(id);

            if (lection is null)
            {
                return NotFound(ValidationMessageGenerator.GetDeleteFailureMessage("Лекция"));
            }

            _repository.LectionsCommands.Delete(id);

            return Ok(ValidationMessageGenerator.GetDeleteSuccessMessage("Лекция"));
        }

        /// <summary>
        /// Получение лекции по id
        /// </summary>
        /// <param name="id">Id лекции</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetLection(int id)
        {
            Lection lection = _repository.LectionsQueries.Get(id);

            if (lection is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Лекция"));
            }

            return Ok(Json(_mapper.Map<LectionModel>(_repository.LectionsQueries.Get(id))));
        }
    }
}
