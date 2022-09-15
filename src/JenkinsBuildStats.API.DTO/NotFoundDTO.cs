namespace JenkinsBuildStats.API.DTO
{
    public sealed class NotFoundDTO
    {
        public string Message { get; }
        public NotFoundDTO(string message)
        {
            Message = message;
        }
    }
}
