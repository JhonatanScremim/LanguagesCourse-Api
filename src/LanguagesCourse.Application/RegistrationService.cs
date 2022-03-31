using AutoMapper;
using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Domain;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using LanguagesCourse.Infra.Interfaces;
using LanguagesCourse.Infra.ViewModels;
using LanguagesCourse.Repository.Interfaces;

namespace LanguagesCourse.Application
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IStudentRepository _studentRepostory;
        private readonly IClassRepository _classRepository;
        private readonly IValidationHelper _validationHelper;
        private readonly IMapper _mapper;

        public RegistrationService(IBaseRepository baseRepository, IRegistrationRepository registrationRepository, IStudentRepository studentRepostory, IClassRepository classRepository, IValidationHelper validationHelper, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _registrationRepository = registrationRepository;
            _studentRepostory = studentRepostory;
            _classRepository = classRepository;
            _validationHelper = validationHelper;
            _mapper = mapper;
        }

        public async Task<List<RegistrationViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<RegistrationViewModel>>(await _registrationRepository.GetAllAsync());
        }

        public async Task<RegistrationViewModel> CreateAsync(RegistrationDTO model)
        {
            var student = await _studentRepostory.GetByIdAsync(model.StudentId);
            if (student == null)
                throw new BadRequestException("Student not found");
            
            await _validationHelper.ValidateClass(model.ClassId);

            var oldStudent = await _registrationRepository.GetByStudentClass(model.StudentId, model.ClassId);

            if(oldStudent != null)
                throw new BadRequestException("Registration already exists");
            
            var registration = _mapper.Map<Registration>(model);

            _baseRepository.Create(registration);
            
            if(!await _baseRepository.SaveChangesAsync())
                throw new BadRequestException("Could not create");

            return _mapper.Map<RegistrationViewModel>(registration);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var oldRegistration = await _registrationRepository.GetByIdAsync(id);

            if (oldRegistration == null)
                throw new BadRequestException("Registration not found");

            _baseRepository.Delete(oldRegistration);

            return await _baseRepository.SaveChangesAsync();
        }
    }
}