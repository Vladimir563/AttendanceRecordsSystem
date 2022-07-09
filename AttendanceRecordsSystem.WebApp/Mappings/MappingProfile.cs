using AttendanceRecordsSystem.Domain.Core;
using AttendanceRecordsSystem.WebApp.Models;
using AutoMapper;

#pragma warning disable CS1591
namespace AttendanceRecordsSystem.WebApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.StudentsGroupId))
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
                .ForMember(dest => dest.AttendedLections, opt => opt.MapFrom(src => src.AttendedLections));

            CreateMap<Lector, LectorModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.LastName + " " + src.FirstName + " " + src.Patronymic))
                .ForMember(dest => dest.Lections, opt => opt.MapFrom(src => src.Lections));

            CreateMap<Lection, LectionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tittle, opt => opt.MapFrom(src => src.Tittle))
                .ForMember(dest => dest.Mark, opt => opt.MapFrom(src => src.Mark))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.LectorId, opt => opt.MapFrom(src => src.LectorId))
                .ForMember(dest => dest.Lector, opt => opt.MapFrom(src => src.Lector));

            CreateMap<StudentsGroup, StudentsGroupModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));
        }
    }
}
