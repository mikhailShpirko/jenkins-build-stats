# Projects description

Structure aspired by this [article](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice).

    .
    ├── JenkinsBuildStats.API                               # API Gateway. Application Layer.
    ├── JenkinsBuildStats.API.DTO                           # Shared project with Data Transfer Objects that are used in Presentation Layer
    ├── JenkinsBuildStats.Domain                            # Domain Entities, Business Logic, Requests and Handlers implementation
    ├── JenkinsBuildStats.Infrastructure                    # Data persistence, Jenkins API integration
    └── JenkinsBuildStats.WebUI                             # Presentation Layer      
    