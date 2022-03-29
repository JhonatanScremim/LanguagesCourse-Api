using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.ViewModels;

namespace LanguagesCourse.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentViewModel>> GetAllAsync();
        Task<StudentViewModel> CreateAsync(StudentDTO model);
        Task<StudentViewModel> UpdateAsync(StudentUpdateDTO model, int studentId);
        Task<bool> DeleteAsync(int studentId);
    }
}