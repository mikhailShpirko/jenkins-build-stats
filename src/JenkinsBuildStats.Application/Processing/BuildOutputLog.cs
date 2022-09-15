namespace JenkinsBuildStats.Application.Processing
{
    public sealed record BuildOutputLog
    {        
        public TimeSpan TimeSpan { get; }
        public string LogText { get; }

        public BuildOutputLog(TimeSpan timeSpan,
            string logText)
        {
            TimeSpan = timeSpan;
            LogText = logText;
        }
    }
}
