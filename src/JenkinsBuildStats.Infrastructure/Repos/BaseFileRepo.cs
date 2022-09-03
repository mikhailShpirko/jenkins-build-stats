using JenkinsBuildStats.Infrastructure.DataStorage;

namespace JenkinsBuildStats.Infrastructure.Repos
{
    public abstract class BaseFileRepo<T> where T : class
    {
        private readonly IFileStorage _fileStorage;
        private readonly string _fileName;
        protected BaseFileRepo(IFileStorage fileStorage,
            string fileName)
        {
            _fileStorage = fileStorage;
            _fileName= fileName;
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken)
        {
            return await _fileStorage
                .GetAsync<T>(_fileName,
                    cancellationToken);
        }

        public async Task SaveAsync(T entity, CancellationToken cancellationToken)
        {
            await _fileStorage
                .SaveAsync(_fileName,
                    entity,
                    cancellationToken);
        }
    }
}
