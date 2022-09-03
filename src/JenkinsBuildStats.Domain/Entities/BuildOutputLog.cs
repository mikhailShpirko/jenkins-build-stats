namespace JenkinsBuildStats.Domain.Entities
{
    public class BuildOutputLog
    {        
        public readonly TimeSpan TimeSpan;
        public readonly string LogText;

        public BuildOutputLog(TimeSpan timeSpan,
            string logText)
        {
            TimeSpan = timeSpan;
            LogText = logText;
        }
    }
}
