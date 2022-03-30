using System.ComponentModel.DataAnnotations;

namespace LanguagesCourse.Infra.DTOs
{
    public class ClassDTO
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}