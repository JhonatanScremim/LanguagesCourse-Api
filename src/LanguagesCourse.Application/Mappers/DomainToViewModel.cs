using AutoMapper;
using LanguagesCourse.Domain;
using LanguagesCourse.Infra.ViewModels;

namespace LanguagesCourse.Application.Mappers
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Student, StudentViewModel>()
                .AfterMap((s, d) => 
                {
                    if(s.Registrations != null && d.Classes != null)
                    {
                        foreach(var item in s.Registrations)
                        {
                            d.Classes.Add(new ClassViewModel()
                            {
                                Id = item.Class.Id,
                                Number = item.Class.Number,
                                Grade = item.Class.Grade
                            }); 
                        }
                    }
                });
        }
    }
}