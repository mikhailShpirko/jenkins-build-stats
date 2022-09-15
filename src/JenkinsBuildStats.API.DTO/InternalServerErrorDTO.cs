namespace JenkinsBuildStats.API.DTO
{
    public sealed class InternalServerErrorDTO
    {
        public string Message { get; }

        public InternalServerErrorDTO(string message)
        {
            Message = message;
        }
    }
}
