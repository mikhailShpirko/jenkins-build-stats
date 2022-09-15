# Projects description

Structure aspired by this [article](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice).

    .
    ├── JenkinsBuildStats.API                               # API Gateway. Mapping HTTP requests to application layer
    ├── JenkinsBuildStats.API.DTO                           # Shared project with Data Transfer Objects that are used in Presentation Layer
    ├── JenkinsBuildStats.Application                       # Business Logic, Requests and Handlers implementation, Validation
    ├── JenkinsBuildStats.Domain                            # Domain Entities
    ├── JenkinsBuildStats.Infrastructure                    # Data persistence, Jenkins API integration
    └── JenkinsBuildStats.WebUI                             # Presentation Layer. Simple UI + API Gateway client      
    