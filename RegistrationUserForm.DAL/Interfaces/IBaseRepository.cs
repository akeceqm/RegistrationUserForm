namespace AutorizationUserForm.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task Create(T entity);
    IQueryable<T> GetAll();
}