namespace LanguagesCourse.Infra.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Grade { get; set; }
        public List<StudentViewModel> Students { get; set; } = new List<StudentViewModel>();
    }
}