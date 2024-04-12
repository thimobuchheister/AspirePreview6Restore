var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");



var apiService = builder.AddProject<Projects.AspirePreview6Restore_ApiService>("apiservice");

builder.AddProject<Projects.AspirePreview6Restore_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
