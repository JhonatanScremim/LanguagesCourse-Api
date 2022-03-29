namespace LanguagesCourse.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}