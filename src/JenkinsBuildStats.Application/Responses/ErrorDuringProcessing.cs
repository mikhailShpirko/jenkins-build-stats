namespace JenkinsBuildStats.Application.Responses
{
    public sealed record ErrorDuringProcessing
    {
        public Exception Exception { get; }
        public ErrorDuringProcessing(Exception exception)
        {
            Exception = exception;
        }
    }
}
