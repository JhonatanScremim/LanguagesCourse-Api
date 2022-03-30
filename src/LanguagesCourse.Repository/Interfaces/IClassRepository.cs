using LanguagesCourse.Domain;

namespace LanguagesCourse.Repository.Interfaces
{
    public interface IClassRepository
    {
        Task<Class?> GetByIdAsync(int id);
        Task<List<Class>> GetClassesByListIdsAsync(List<int> ids);
    }
}