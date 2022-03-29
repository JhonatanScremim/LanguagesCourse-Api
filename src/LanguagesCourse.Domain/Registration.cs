namespace LanguagesCourse.Domain
{
    public class Registration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public Student Student { get; set; } = new Student();
        public Class Class { get; set; } = new Class();
    }
}