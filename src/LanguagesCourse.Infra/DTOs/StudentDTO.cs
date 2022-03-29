using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
namespace LanguagesCourse.Infra.DTOs
{
    public class StudentDTO
    {
        [Required, StringLength(100, MinimumLength = 4)]
        public string? Name { get; set; }

        [Required, StringLength(100, MinimumLength = 4)]
        public string? Email { get; set; }
        
        [Required, StringLength(11, MinimumLength = 11)]
        public string? Cpf { get; set; }

        [Required]
        public List<int> ClassesId {get; set; } = new List<int>(); 
    }
}