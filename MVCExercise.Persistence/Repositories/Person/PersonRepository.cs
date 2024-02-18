using MVCExercise.Persistence.Context;

namespace MVCExercise.Persistence.Repositories.Person
{
    public class PersonRepository : BaseRepository<Domain.Entities.Person>, IPersonRepository
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }
    }
}
