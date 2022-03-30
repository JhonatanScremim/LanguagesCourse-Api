using LanguagesCourse.Infra.DTOs;
using LanguagesCourse.Infra.ViewModels;

namespace LanguagesCourse.Application.Interfaces
{
    public interface IRegistrationService
    {
         Task<List<RegistrationViewModel>> GetAllAsync();
         Task<RegistrationViewModel> CreateAsync(RegistrationDTO model);
         Task<bool> DeleteAsync(int id);
    }
}