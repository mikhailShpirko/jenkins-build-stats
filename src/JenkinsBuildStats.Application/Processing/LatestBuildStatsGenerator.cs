using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Domain.Entities;

namespace JenkinsBuildStats.Application.Processing
{
    internal sealed class LatestBuildStatsGenerator : ILatestBuildStatsGenerator
    {
        private readonly IJenkinsApiClient _jenkinsApiClient;
        private readonly IReadOnlyCollection<SectionConfig> _sectionConfigs;

        public LatestBuildStatsGenerator(IJenkinsApiClient jenkinsApiClient,
            IReadOnlyCollection<SectionConfig> sectionConfigs)
        {
            _jenkinsApiClient = jenkinsApiClient;
            _sectionConfigs = sectionConfigs;
        }

        public async Task<BuildStats> GenerateForProjectAsync(Project project, 
            CancellationToken cancellationToken)
        {
            var buildLogs = await _jenkinsApiClient
                .GetLastBuildLogsAsync(project.Name,
                    cancellationToken);


            var sectionsStats = _sectionConfigs
                .ToDictionary(s => s.Section, s => new IntermediateSectionStats());


            foreach (var buildLog in buildLogs)
            {

                foreach (var sectionConfig in _sectionConfigs
                    .Where(s => buildLog.LogText.Contains(s.StartsWith) || buildLog.LogText.Contains(s.EndsWith)))
                {
                    if (buildLog.LogText.Contains(sectionConfig.StartsWith))
                    {
                        sectionsStats[sectionConfig.Section].StartedAt = buildLog.TimeSpan;
                    }

                    if (buildLog.LogText.Contains(sectionConfig.EndsWith))
                    {
                        sectionsStats[sectionConfig.Section].EndedAt = buildLog.TimeSpan;
                    }
                }
            }

            var buildStartTimespan = buildLogs.First().TimeSpan;
            var buildEndTimespan = buildLogs.Last().TimeSpan;

            return new BuildStats
            {
                Project = project,
                StartedAt = buildStartTimespan,
                EndedAt = buildEndTimespan,
                SectionsStats = sectionsStats
                    .Select(s => new SectionStats
                    {
                        Section = s.Key,
                        StartedAt = s.Value.StartedAt,
                        EndedAt = s.Value.EndedAt
                    })
                    .ToList()
            };
        }
    }
}
