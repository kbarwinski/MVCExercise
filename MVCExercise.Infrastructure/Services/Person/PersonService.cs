using MVCExercise.Persistence.Models;
using MVCExercise.Persistence.Queries.Pagination;
using MVCExercise.Persistence.Repositories.Person;
using MVCExercise.Persistence.Repositories.UnitOfWork;
using System.Linq.Expressions;

namespace MVCExercise.Infrastructure.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IPersonRepository personRepository, IUnitOfWork unitOfWork)
        {
            _personRepository = personRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Create(Domain.Entities.Person entity, CancellationToken cancellationToken)
        {
            _personRepository.Create(entity);

            await _unitOfWork.Save(cancellationToken);
        }

        public async Task Update(Domain.Entities.Person entity, CancellationToken cancellationToken)
        {
            _personRepository.Update(entity);

            await _unitOfWork.Save(cancellationToken);
        }

        public async Task Delete(Domain.Entities.Person entity, CancellationToken cancellationToken)
        {
            _personRepository.Delete(entity);

            await _unitOfWork.Save(cancellationToken);
        }

        public async Task<Domain.Entities.Person?> Get(Expression<Func<Domain.Entities.Person, bool>> predicate, CancellationToken cancellationToken)
        {
            var res = await _personRepository.Get(predicate, cancellationToken, asNoTracking: false, includeProperties:x => x.Emails);

            return res;
        }

        public async Task<(List<Domain.Entities.Person>, PaginationModel)> GetPage(PaginationQuery pagination,
            Dictionary<Expression<Func<Domain.Entities.Person, bool>>, bool> filterPredicates,
            Dictionary<string, Expression<Func<Domain.Entities.Person, object>>> orderPredicates,
            CancellationToken cancellationToken)
        {
            var res = await _personRepository.GetFilteredAndOrderedPage(pagination, filterPredicates, orderPredicates, cancellationToken, includeProperties: x => x.Emails);

            return res;
        }
    }
}
