namespace JenkinsBuildStats.Application.Contract
{
    public interface IRepo<T>
    {
        Task<T> GetAsync(CancellationToken cancellationToken);
        Task SaveAsync(T entity, CancellationToken cancellationToken);
    }
}
