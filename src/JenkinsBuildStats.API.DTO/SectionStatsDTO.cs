﻿namespace JenkinsBuildStats.API.DTO
{
    public class SectionStatsDTO
    {
        public SectionDTO Section { get; set; }
        public TimeSpan StartedAt { get; set; }
        public TimeSpan EndedAt { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
