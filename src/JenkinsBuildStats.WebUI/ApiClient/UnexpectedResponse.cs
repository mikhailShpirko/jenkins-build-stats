namespace JenkinsBuildStats.WebUI.ApiClient
{
    public class UnexpectedResponse
    {
        public string Message { get; }

        public UnexpectedResponse(string message)
        {
            Message = message;
        }
    }
}
