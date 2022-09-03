using System.Text.Json;

namespace JenkinsBuildStats.Infrastructure.DataStorage
{
    public class JsonFileStorage : IFileStorage
    {
        private readonly string _filesPath;

        public JsonFileStorage(StorageDirectory storageDirectory)
        {
            _filesPath = storageDirectory.Path;
        }

        public async Task<T> GetAsync<T>(string fileName, CancellationToken cancellationToken) where T : class
        {
            var filePath = CreateFilePath(fileName);
            if (!File.Exists(filePath))
            {
                return null;
            }

            await using FileStream readStream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<T>(readStream, cancellationToken: cancellationToken);
        }

        public async Task SaveAsync(string fileName, object contents, CancellationToken cancellationToken)
        {
            await using FileStream createStream = File.Create(CreateFilePath(fileName));
            await JsonSerializer.SerializeAsync(createStream, contents, cancellationToken: cancellationToken);
        }

        private string CreateFilePath(string fileName)
        {
            return Path.Combine(_filesPath, $"{fileName}.json");
        }
    }
}
