namespace JenkinsBuildStats.Infrastructure.DataStorage
{
    public sealed record StorageDirectory
    {
        public string Path { get; }

        public StorageDirectory(string path)
        {
            Path = path;
        }

    }
}
