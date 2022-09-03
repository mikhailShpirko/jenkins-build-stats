
namespace JenkinsBuildStats.Domain.Responses
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
