using MVCExercise.Persistence.Context;
using MVCExercise.Persistence.Repositories.Email;

namespace MVCExercise.Persistence.Repositories.Email
{
    public class EmailRepository : BaseRepository<Domain.Entities.Email>, IEmailRepository
    {
        public EmailRepository(DataContext context) : base(context)
        {
        }
    }
}
