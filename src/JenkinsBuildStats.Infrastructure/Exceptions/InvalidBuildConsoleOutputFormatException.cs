namespace JenkinsBuildStats.Infrastructure.Exceptions
{
    public class InvalidBuildConsoleOutputFormatException : Exception
    {
        public InvalidBuildConsoleOutputFormatException(string line) :
            base ($"Invalid line '{line}'. Console Output must have string formate - {{time hh:mm:ss}} {{log text}}")
        {

        }
    }
}
