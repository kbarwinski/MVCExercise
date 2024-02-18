using AutoMapper;

namespace MVCExercise.Models.Person
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<Domain.Entities.Person, PersonViewModel>()
                .ForMember(o => o.FirstEmailAddress, s => s.MapFrom(m => m.Emails.Any() ? m.Emails.First().Address : "N/A"));

            CreateMap<Domain.Entities.Person, PersonFormViewModel>();
            CreateMap<PersonFormViewModel, Domain.Entities.Person>();
        }
    }
}
