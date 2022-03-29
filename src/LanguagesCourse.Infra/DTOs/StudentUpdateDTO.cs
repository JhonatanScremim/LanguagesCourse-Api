using System.ComponentModel.DataAnnotations;

namespace LanguagesCourse.Infra.DTOs
{
    public class StudentUpdateDTO
    {
        [Required, StringLength(100, MinimumLength = 4)]
        public string Name { get; set; }

        [Required, StringLength(100, MinimumLength = 4)]
        public string Email { get; set; }
        
        [Required, StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        public StudentUpdateDTO(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }
    }
}