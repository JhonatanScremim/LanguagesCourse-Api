using AutoMapper;
using LanguagesCourse.Application.Interfaces;
using LanguagesCourse.Domain;
using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.Exceptions;
using LanguagesCourse.Infra.ViewModels;
using LanguagesCourse.Repository.Interfaces;

namespace LanguagesCourse.Application
{
    public class ClassService : IClassService
    {
        private readonly IBaseRepository _baseRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public async Task<List<ClassViewModel>> GetAllAsync()
        {
            return _mapper.Map<List<ClassViewModel>>(await _classRepository.GetAllAsync());
        }

        public ClassService(IBaseRepository baseRepository, IClassRepository classRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<ClassViewModel> CreateAsync(ClassDTO model)
        {
            var newClass = _mapper.Map<Class>(model);

            _baseRepository.Create(newClass);

            if(!await _baseRepository.SaveChangesAsync())
                throw new BadRequestException("Could not create");

            return _mapper.Map<ClassViewModel>(newClass);
        }

        public async Task<ClassViewModel> UpdateAsync(ClassDTO model, int classId)
        {
            var oldClass = await _classRepository.GetByIdAsync(classId);

            if (oldClass == null)
                throw new BadRequestException("Class not found");

            var newClass = _mapper.Map<Class>(model);
            newClass.Id = classId;
            _baseRepository.Update(newClass);

            if(!await _baseRepository.SaveChangesAsync())
                throw new BadRequestException("Could not update");

            return _mapper.Map<ClassViewModel>(newClass);
        }
        
        public async Task<bool> DeleteAsync(int classId)
        {
            var oldClass = await _classRepository.GetByIdAsync(classId);

            if(oldClass == null)
                throw new BadRequestException("Class not found");

            if(oldClass.Registrations == null || oldClass.Registrations.Any())
                throw new BadRequestException("Could not delete, Class is has students");

            _baseRepository.Delete(oldClass);

            return await _baseRepository.SaveChangesAsync();
        }
    }
}