namespace LanguagesCourse.Domain
{
    public class Class
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Grade { get; set; }
        public List<Registration> Registrations { get; set; } = new List<Registration>();
    }
}