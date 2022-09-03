﻿namespace JenkinsBuildStats.Domain.Processing
{
    public class IntermediateSectionStats
    {
        public TimeSpan StartedAt { get; set; } = TimeSpan.MinValue;
        public TimeSpan EndedAt { get; set; } = TimeSpan.MaxValue;
    }
}