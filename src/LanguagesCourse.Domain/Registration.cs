namespace LanguagesCourse.Domain
{
    public class Registration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Student? Student { get; set; }
        public Class? Class { get; set; }
    }
}