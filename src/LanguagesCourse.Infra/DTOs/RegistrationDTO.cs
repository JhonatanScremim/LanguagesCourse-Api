using System.ComponentModel.DataAnnotations;

namespace LanguagesCourse.Infra.DTOs
{
    public class RegistrationDTO
    {
        [Range(1, Int32.MaxValue)]
        public int StudentId { get; set; }
        [Range(1, Int32.MaxValue)]
        public int ClassId { get; set; }
    }
}