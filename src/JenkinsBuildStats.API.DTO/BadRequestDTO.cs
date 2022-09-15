namespace JenkinsBuildStats.API.DTO
{
    public sealed class BadRequestDTO
    {
        public IEnumerable<string> ErrorMessages { get; init; }
    }
}
