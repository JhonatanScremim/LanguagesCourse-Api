using LanguagesCourse.Domain;

namespace LanguagesCourse.Repository.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>?> GetAllAsync();
        Task<Class?> GetByIdAsync(int id);
        Task<List<Class>> GetClassesByListIdsAsync(List<int> ids);
    }
}