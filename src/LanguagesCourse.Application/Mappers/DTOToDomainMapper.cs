using AutoMapper;
using LanguagesCourse.Domain;
using LanguagesCourse.Infra.DTOs;

namespace LanguagesCourse.Application.Mappers
{
    public class DTOToDomainMapper : Profile
    {
        public DTOToDomainMapper()
        {
            CreateMap<StudentDTO, Student>();
        }
    }
}