using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Processing;
using JenkinsBuildStats.Application.Requests;
using JenkinsBuildStats.Application.Responses;
using JenkinsBuildStats.Domain.Entities;
using MediatR;
using System.Collections.Concurrent;

namespace JenkinsBuildStats.Application.Handlers
{
    public sealed class GenerateLastSuccessfulBuildStatsHandler : IRequestHandler<GenerateLastSuccessfulBuildStatsRequest, GenerateLastSuccessfulBuildStatsResponse>
    {
        private readonly ISettingsRepo _settingsRepo;
        private readonly ILatestBuildStatsGeneratorBuilder _latestBuildStatsGeneratorBuilder;
        private readonly ILastSuccessfulBuildStatsRepo _repo;
        
        public GenerateLastSuccessfulBuildStatsHandler(
            ISettingsRepo settingsRepo,
            ILatestBuildStatsGeneratorBuilder latestBuildStatsGeneratorBuilder,
            ILastSuccessfulBuildStatsRepo repo)
        {            
            _settingsRepo = settingsRepo;
            _latestBuildStatsGeneratorBuilder = latestBuildStatsGeneratorBuilder;
            _repo = repo;
        }

        public async Task<GenerateLastSuccessfulBuildStatsResponse> Handle(GenerateLastSuccessfulBuildStatsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var settings = await _settingsRepo.GetAsync(cancellationToken);
                if (settings is null)
                {
                    return new EntityDoesNotExist<Settings>();
                }

                var statsGenerator = _latestBuildStatsGeneratorBuilder
                    .Build(settings.JenkinsClientConfig,
                        settings.SectionConfigs);

                var buildStats = new ConcurrentBag<BuildStats>();

                var taskList = settings
                    .Projects
                    .Select(p =>
                    {
                        return Task.Run(async () => {
                            var buildStat = await statsGenerator
                            .GenerateForProjectAsync(p, 
                                cancellationToken);

                            buildStats.Add(buildStat);
                        });
                    });

                await Task.WhenAll(taskList);

                var lastSuccessfulBuildStats = new LastSuccessfulBuildStats
                {
                    BuildStats = buildStats
                };

                await _repo.SaveAsync(lastSuccessfulBuildStats, cancellationToken);

                return new SuccessfullySaved<LastSuccessfulBuildStats>();
            }
            catch (Exception e)
            {
                return new ErrorDuringProcessing(e);
            }
        }
    }
}
