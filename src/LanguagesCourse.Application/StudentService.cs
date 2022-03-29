using AutoMapper;
using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Domain;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using LanguagesCourse.Infra.ViewModels;
using LanguagesCourse.Repository.Interfaces;

namespace LanguagesCourse.Application
{
    public class StudentService : IStudentService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public StudentService(IBaseRepository baseRepository, IClassRepository classRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<StudentViewModel> CreateAsync(StudentDTO model)
        {
            var student = _mapper.Map<Student>(model);

            var classes = await _classRepository.GetClassesByListIdsAsync(model.ClassesId);

            if(classes.Count < model.ClassesId.Count)
                throw new BadRequestException("Not found all Classes by Ids");

            foreach (var registration in from id in model.ClassesId
                                       let registration = new Registration()
                                       {
                                           ClassId = id,
                                           Student = student
                                       }
                                       select registration)
                _baseRepository.Create(registration);

            
            if(!await _baseRepository.SaveChangesAsync())
                throw new BadRequestException("Could not create");

            return _mapper.Map<StudentViewModel>(student);
        }
    }
}