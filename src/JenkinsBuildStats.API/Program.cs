using FluentValidation;
using JenkinsBuildStats.Domain.Contract;
using JenkinsBuildStats.Domain.Processing;
using JenkinsBuildStats.Infrastructure.ApiClients;
using JenkinsBuildStats.Infrastructure.DataStorage;
using JenkinsBuildStats.Infrastructure.Repos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<StorageDirectory>(x => new StorageDirectory(builder.Configuration["StorageFolderPath"]));
builder.Services.AddScoped<IFileStorage, JsonFileStorage>();
builder.Services.AddScoped<ISettingsRepo, SettingsFileRepo>();
builder.Services.AddScoped<ILastSuccessfulBuildStatsRepo, LastSuccessfulBuildStatsRepoFileRepo>();
builder.Services.AddScoped<IJenkinsApiClientBuilder, JenkinsApiClientBuilder>();
builder.Services.AddScoped<ILatestBuildStatsGeneratorBuilder, LatestBuildStatsGeneratorBuilder>();
builder.Services.AddValidatorsFromAssembly(Assembly.Load("JenkinsBuildStats.Domain"));
builder.Services.AddMediatR(Assembly.Load("JenkinsBuildStats.Domain"));
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler("/error");

app.Run();
