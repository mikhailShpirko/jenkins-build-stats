namespace JenkinsBuildStats.Infrastructure.DataStorage
{
    public interface IFileStorage
    {
        Task SaveAsync(string fileName, object contents, CancellationToken cancellationToken);
        Task<T> GetAsync<T>(string fileName, CancellationToken cancellationToken) where T : class;
    }
}
