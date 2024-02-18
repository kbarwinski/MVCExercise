using MVCExercise.Domain.Common;
using MVCExercise.Persistence.Models;
using MVCExercise.Persistence.Queries.Pagination;
using System.Linq.Expressions;

namespace MVCExercise.Infrastructure.Services
{
    public interface ICRUDService<T> where T : BaseEntity
    {
        Task Create(T entity, CancellationToken cancellationToken);

        Task Update(T entity, CancellationToken cancellationToken);

        Task Delete(T entity, CancellationToken cancellationToken);

        Task<T?> Get(
            Expression<Func<T, bool>> predicate,
            CancellationToken cancellationToken);

        Task<(List<T>, PaginationModel)> GetPage(
        PaginationQuery pagination,
        Dictionary<Expression<Func<T, bool>>, bool> filterPredicates,
        Dictionary<string, Expression<Func<T, object>>> orderPredicates,
        CancellationToken cancellationToken);

    }
}
