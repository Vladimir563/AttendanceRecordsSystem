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

{    /// <summary>
     /// Контроллер для манипуляций с моделью студента
     /// </summary>
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repository;
        private readonly IValidator<Student> _validator;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        /// <param name="validator"></param>
        public StudentController(IMapper mapper, IUnitOfWork repository, IValidator<Student> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        /// <summary>
        /// Добавление нового студента
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateStudent(string fName, string lName, int groupId)
        {
            Student student = new Student()
            {
                FirstName = fName,
                LastName = lName,
                GroupId = groupId
            };

            string validationErrors = _validator.ValidateEntity(student);

            if (string.IsNullOrEmpty(validationErrors) == false)
            {
                return BadRequest($"{ValidationMessageGenerator.GetValidateFailureMessage()}: \n{validationErrors}");
            }

            StudentsGroup sGroup = _repository.StudentsGroupsQueries.Get(groupId);

            if (sGroup is null) return NotFound($"{ValidationMessageGenerator.GetNotFoundMessage("Группа студента")} \n{Json(sGroup)}");

            student.Group = sGroup;

            _repository.StudentsCommands.Create(student);

            StudentModel studentModel = _mapper.Map<StudentModel>(student);

            return Ok($"{ValidationMessageGenerator.GetCreateSuccessMessage("Студент")} \n{Json(studentModel)}");
        }

        /// <summary>
        /// Обновление студента
        /// </summary>
        /// <param name="newStudent">Новый студент</param>
        /// <param name="id">Id студента для обновления</param>
        [HttpPut]
        public IActionResult UpdateStudent(Student newStudent, int id)
        {
            Student student = _repository.StudentsQueries.Get(id);

            if (student is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Студент"));
            }

            _repository.StudentsCommands.Update(newStudent, id);

            return Ok($"{ValidationMessageGenerator.GetUpdateSuccessMessage("Студент")} \n{Json(student)}");
        }

        /// <summary>
        /// Удаление студента
        /// </summary>
        /// <param name="id">Id студента для удаления</param>
        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            Student student = _repository.StudentsQueries.Get(id);

            if (student is null)
            {
                return NotFound(ValidationMessageGenerator.GetDeleteFailureMessage("Студент"));
            }

            _repository.StudentsCommands.Delete(id);

            return Ok(ValidationMessageGenerator.GetDeleteSuccessMessage("Студент"));
        }

        /// <summary>
        /// Получение студента по id
        /// </summary>
        /// <param name="id">Id студента</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetStudent(int id)
        {
            Student student = _repository.StudentsQueries.Get(id);

            if (student is null)
            {
                return NotFound(ValidationMessageGenerator.GetNotFoundMessage("Студент"));
            }

            return Ok(Json(_mapper.Map<StudentModel>(_repository.StudentsQueries.Get(id))));
        }
    }
}
