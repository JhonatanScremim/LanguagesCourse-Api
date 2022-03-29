using LanguagesCourse.Domain;

namespace LanguagesCourse.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>?> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> GetByCpfAsync(string cpf);
    }
}