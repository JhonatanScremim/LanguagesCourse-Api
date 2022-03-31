using LanguagesCourse.Infra.Exceptions;
using LanguagesCourse.Infra.Interfaces;
using LanguagesCourse.Repository.Interfaces;

namespace LanguagesCourse.Infra.Helpers
{
    public class ValidationHelper : IValidationHelper
    {
        private readonly IClassRepository _classRepository;

        public ValidationHelper(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task ValidateClass(int classId)
        {
            var oldClass = await _classRepository.GetByIdAsync(classId);

            if (oldClass == null)
                throw new BadRequestException("Class not found");

            if (oldClass.Registrations.Count >= 5)
                throw new BadRequestException("Class already has 5 students");
        }
    }
}