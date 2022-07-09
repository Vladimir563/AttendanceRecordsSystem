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


namespace AttendanceRecordsSystem.WebApp.Controllers
{
    /// <summary>
    /// Контроллер для манипуляций с моделью группы студентов
    /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class StudentsGroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repository;
        private readonly IValidator<StudentsGroup> _validator;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="validator"></param>
        public StudentsGroupController(IMapper mapper, IUnitOfWork repository, IValidator<StudentsGroup> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }



        /// <summary>
        /// Добавление новой группы студентов
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateStudentsGroup(string groupName)
        {
            StudentsGroup studentsGroup = new StudentsGroup()
            {
                Name = groupName
            };

            string validationErrors = _validator.ValidateEntity(studentsGroup);

            if (string.IsNullOrEmpty(validationErrors) == false)
            {
                return BadRequest($"{ValidationMessageGenerator.GetValidateFailureMessage()}: \n{validationErrors}");
            }

            _repository.StudentsGroupsCommands.Create(studentsGroup);

            StudentsGroupModel studentsGroupModel = _mapper.Map<StudentsGroupModel>(studentsGroup);

            return Ok($"{ValidationMessageGenerator.GetCreateSuccessMessage("Группа студентов")} \n{Json(studentsGroupModel)}");
        }

        /// <summary>
        /// Обновление группы студентов
        /// </summary>
        /// <param name="newStudentsGroup">Новая группа студентов</param>
        /// <param name="id">Id группы студентов для обновления</param>
        [HttpPut]
        public IActionResult UpdateStudentsGroup(StudentsGroup newStudentsGroup, int id)
        {
            StudentsGroup studentsGroup = _repository.StudentsGroupsQueries.Get(id);

            if (studentsGroup is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Группа студентов"));
            }

            _repository.StudentsGroupsCommands.Update(newStudentsGroup, id);

            return Ok($"{ValidationMessageGenerator.GetUpdateSuccessMessage("Группа студентов")} \n{Json(studentsGroup)}");
        }

        /// <summary>
        /// Удаление группы студентов
        /// </summary>
        /// <param name="id">Id группы студентов для удаления</param>
        [HttpDelete]
        public IActionResult DeleteStudentsGroup(int id)
        {
            StudentsGroup studentsGroup = _repository.StudentsGroupsQueries.Get(id);

            if (studentsGroup is null)
            {
                return NotFound(ValidationMessageGenerator.GetDeleteFailureMessage("Группа студентов"));
            }

            _repository.StudentsGroupsCommands.Delete(id);

            return Ok(ValidationMessageGenerator.GetDeleteSuccessMessage("Группа студентов"));
        }

        /// <summary>
        /// Получение группы студентов по id
        /// </summary>
        /// <param name="id">Id группы студентов</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStudentsGroup(int id)
        {
            StudentsGroup studentsGroup = _repository.StudentsGroupsQueries.Get(id);

            if (studentsGroup is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Группа студентов"));
            }

            return Ok(Json(_mapper.Map<StudentsGroupModel>(_repository.StudentsGroupsQueries.Get(id))));
        }
    }
}
