namespace JenkinsBuildStats.Application.Responses
{
    public class ErrorDuringProcessing
    {
        public readonly Exception Exception;
        public ErrorDuringProcessing(Exception exception)
        {
            Exception = exception;
        }
    }
}
