# Jenkins Build Stats
A utility that I made for me to view aggregated build statistics. I am closely monitoring execution time and where and which process was taking most of the time of last successful build. However, reviewing manually console output for each project is not efficient, so I ended up building this utility.

Main goal of this project was to make my daily routine efficient and less time consuming. Additional technical goals I had in mind:
- Apply DDD and CQRS using MediatR
- Create clean architecture
- Have a tidy solution structure
- Cover most critical logic with UT and use Fluent Assertions
- Try out consuming Jenkins API
- Try out Blazor WASM as a front-end

## How it works
The utility gets build console output with timestamp from Jenkins API for each project defined in settings, parses it and shows execution timestamps and duration per project per section defined in settings. Therefore, the utility will require you to first provide valid settings:
- Jenkins Client Configuration: obtain and provide endpoint URL, dedicated username and API Token for that user
- Projects: define exact project names as defined in Jenkins
- Sections: define sections of build output to provide stats, name of section, text of start of the section and text of end of the section in the build console output


## Launch instructions
Execute the following commands to run the project to play around with it:

```
docker compose -f deploy/JenkinsBuildStats.DockerCompose.yaml -p jenkins_build_stats up -d --build
```

After that you will be able to test the API documentation via http://localhost:9898/swagger/

Web UI will be available at: http://localhost:9889/

Execute the following command to shut down the project:

```
docker compose -f deploy/JenkinsBuildStats.DockerCompose.yaml -p jenkins_build_stats down
```

## Project structure
    .
    ├── deploy                                              # deployment scripts and configuration files
    ├── docker                                              # docker files for project components
    ├── src                                                 # source code for apps
    └── tests                                               # unit tests       
    

## Limitations
- Primitive data storage. Everything is stored in .json files.  Didn't want to invest time in saving data to any database engines and applying ORM. Current solution satisfies my needs.
- Clunky front-end. Didn't want to invest time in any fancy UI/UX. Simple UI is enough for my needs.
- Only Last Successful Build. The utility stores only results of the last successful build for all projects defined. May be in future I'll add support to store historical data and multiple builds.
- Section configuration for all projects. Currently all Jenkins projects that I have share same build steps and same sections configuration consequently. Other use-cases might assume different scenario to be applied.