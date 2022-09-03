namespace JenkinsBuildStats.API.DTO
{
    public class InternalServerErrorDTO
    {
        public string Message { get; }

        public InternalServerErrorDTO(string message)
        {
            Message = message;
        }
    }
}
