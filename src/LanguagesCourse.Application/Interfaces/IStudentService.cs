using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.ViewModels;

namespace LanguagesCourse.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentViewModel> CreateAsync(StudentDTO model);
    }
}