namespace LanguagesCourse.Infra.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public List<ClassViewModel> Classes { get; set; } = new List<ClassViewModel>();
        
        

    }
}