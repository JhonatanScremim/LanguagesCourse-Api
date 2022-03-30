using LanguagesCourse.Domain;

namespace LanguagesCourse.Repository.Interfaces
{
    public interface IRegistrationRepository
    {
         Task<List<Registration>> GetAllAsync();
         Task<Registration?> GetByIdAsync(int id);
         Task<Registration?> GetByStudentClass(int studentId, int classId);
    }
}