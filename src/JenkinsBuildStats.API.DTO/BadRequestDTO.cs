namespace JenkinsBuildStats.API.DTO
{
    public class BadRequestDTO
    {
        public IEnumerable<string> ErrorMessages { get; init; }
    }
}
