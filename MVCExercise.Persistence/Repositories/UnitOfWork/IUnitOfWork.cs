namespace MVCExercise.Persistence.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task Save(CancellationToken cancellationToken);
    }
}
