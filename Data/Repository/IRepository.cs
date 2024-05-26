namespace Data.Repository;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
}