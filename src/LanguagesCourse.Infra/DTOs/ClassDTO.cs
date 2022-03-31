using System.ComponentModel.DataAnnotations;

namespace LanguagesCourse.Infra.DTOs
{
    public class ClassDTO
    {
        [Range(1, 100)]
        public int Number { get; set; }
        [Range(1, 100)]
        public int Grade { get; set; }
    }
}