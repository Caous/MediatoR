namespace PatternMediatorWithMediatorR.Infrastructure.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();

    Task<T> Get(Guid id);

    Task Save(T item);

    Task Edit(T item);

    Task Delete(Guid id);
}
