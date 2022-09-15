using JenkinsBuildStats.Application.Contract;
using JenkinsBuildStats.Application.Processing;
using JenkinsBuildStats.Infrastructure.ApiClients;
using JenkinsBuildStats.Infrastructure.DataStorage;
using JenkinsBuildStats.Infrastructure.Repos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JenkinsBuildStats.Infrastructure
{
    public static class ServicesConfiguration
    {
        private const string _storageFolderConfigurationKey = "StorageFolderPath";
        public static void Configure(IServiceCollection services, 
            ConfigurationManager configuration)
        {
            services.AddScoped(x => new StorageDirectory(configuration[_storageFolderConfigurationKey]));
            services.AddScoped<IFileStorage, JsonFileStorage>();
            services.AddScoped<ISettingsRepo, SettingsFileRepo>();
            services.AddScoped<ILastSuccessfulBuildStatsRepo, LastSuccessfulBuildStatsRepoFileRepo>();
            services.AddScoped<IJenkinsApiClientBuilder, JenkinsApiClientBuilder>();
            services.AddScoped<ILatestBuildStatsGeneratorBuilder, LatestBuildStatsGeneratorBuilder>();
        }
    }
}
