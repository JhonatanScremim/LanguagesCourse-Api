namespace LanguagesCourse.Infra.ViewModels
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        public StudentViewModel Student { get; set; } = new StudentViewModel();
        public ClassViewModel Class { get; set; } = new ClassViewModel();
    }
}