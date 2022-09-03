namespace JenkinsBuildStats.Infrastructure.DataStorage
{
    public class StorageDirectory
    {
        public string Path { get; }

        public StorageDirectory(string path)
        {
            Path = path;
        }

    }
}
