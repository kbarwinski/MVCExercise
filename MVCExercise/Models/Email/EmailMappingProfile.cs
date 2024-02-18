using AutoMapper;
using MVCExercise.Models.Person;

namespace MVCExercise.Models.Email
{
    public class EmailMappingProfile : Profile
    {
        public EmailMappingProfile()
        {
            CreateMap<Domain.Entities.Email, EmailViewModel>();
        }
    }
}
