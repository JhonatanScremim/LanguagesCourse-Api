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
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public StudentService(IBaseRepository baseRepository, IStudentRepository studentRepository, IClassRepository classRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _studentRepository = studentRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<StudentViewModel>>(await _studentRepository.GetAllAsync());
        }

        public async Task<StudentViewModel> CreateAsync(StudentDTO model)
        {

            var cpfStudent = await _studentRepository.GetByCpfAsync(model.Cpf);

            if (cpfStudent != null)
                throw new BadRequestException("CPF already exists");

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

        public async Task<StudentViewModel> UpdateAsync(StudentUpdateDTO model, int studentId)
        {
            var oldStudent = await _studentRepository.GetByIdAsync(studentId);

            if (oldStudent == null)
                throw new BadRequestException("Student not found");
            
            var student = _mapper.Map<Student>(model);
            student.Id = studentId;
            _baseRepository.Update(student);
            
            if(!await _baseRepository.SaveChangesAsync())
                throw new BadRequestException("Could not update");

            return _mapper.Map<StudentViewModel>(student);
        }

        public async Task<bool> DeleteAsync(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);

            if(student == null)
                throw new BadRequestException("Student not found");

            _baseRepository.Delete(student);

            return await _baseRepository.SaveChangesAsync();
        }
    }
}