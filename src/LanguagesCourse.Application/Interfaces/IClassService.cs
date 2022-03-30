using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.ViewModels;

namespace LanguagesCourse.Application.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassViewModel>> GetAllAsync();
        Task<ClassViewModel> CreateAsync(ClassDTO model);
        Task<ClassViewModel> UpdateAsync(ClassDTO model, int classId);
        Task<bool> DeleteAsync(int classId);
    }
}