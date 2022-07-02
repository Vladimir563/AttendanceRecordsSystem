using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.Domain.Interfaces;
using AttendanceRecordsSystem.WebApp.Models;
using AttendanceRecordsSystem.WebApp.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace AttendanceRecordsSystem.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Lector> _lectorsRepository;
        private readonly IValidator<Lector> _validator;

         public LectorController(IMapper mapper, IRepository<Lector> lectorsRepository, IValidator<Lector> validator)
        {
            _lectorsRepository = lectorsRepository;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        /// Добавление нового лектора
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="patr"></param>
        /// <param name="lectionIds"></param>
        /// <returns></returns>
        [HttpPost]
        public LectorModel CreateLector(string fName, string lName, string patr, int[] lectionIds)
        {
            Lector lector = new Lector()
            {
                FirstName = fName,
                LastName = lName,
                Patronymic = patr
            };

            _validator.ValidateEntity(lector);

            _lectorsRepository.Create(lector);

            LectorModel lectorModel = _mapper.Map<LectorModel>(lector);

            return lectorModel;
        }

        /// <summary>
        /// Получение лектора по id
        /// </summary>
        /// <param name="id">Id лектора</param>
        /// <returns></returns>
        [HttpGet]
        public LectorModel GetLector(int id) => _mapper.Map<LectorModel>(_lectorsRepository.Get(id));


        [HttpPut]
        public void UpdateLector(Lector newLector, int id)
        {
            Lector lector = _lectorsRepository.Get(id);

            lector = newLector;
        }
    }
}
