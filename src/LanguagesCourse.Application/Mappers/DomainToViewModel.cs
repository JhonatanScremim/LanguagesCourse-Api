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
                            if(item.Class!= null)
                            {
                                d.Classes.Add(new ClassViewModel()
                                {
                                    Id = item.Class.Id,
                                    Number = item.Class.Number,
                                    Grade = item.Class.Grade
                                }); 
                            }
                        }
                    }
                });

            CreateMap<Class, ClassViewModel>()
                .AfterMap((s, d) => 
                {
                    if(s.Registrations != null && d.Students != null)
                    {
                        foreach(var item in s.Registrations)
                        {
                            if(item.Student!= null)
                            {
                                d.Students.Add(new StudentViewModel()
                                {
                                    Id = item.Student.Id,
                                    Name = item.Student.Name,
                                    Email = item.Student.Email,
                                    Cpf = item.Student.Cpf
                                }); 
                            }
                        }
                    }
                });
        }
    }
}