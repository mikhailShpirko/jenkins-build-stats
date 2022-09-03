﻿using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Entities;
using JenkinsBuildStats.Infrastructure.DataStorage;

namespace JenkinsBuildStats.Infrastructure.Repos
{
    public class SettingsFileRepo : 
        BaseFileRepo<Settings>, 
        ISettingsRepo
    {
        public SettingsFileRepo(IFileStorage fileStorage) 
            : base (fileStorage, nameof(Settings))
        {
        }    
    }
}
