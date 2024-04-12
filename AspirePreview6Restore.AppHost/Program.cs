var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var storage = builder
    .AddAzureStorage("storage")
    .RunAsEmulator(container =>
    {
        container.WithDataVolume("Sample.Storage");
    });

var blobs = storage.AddBlobs("blobs");

var apiService = builder.AddProject<Projects.AspirePreview6Restore_ApiService>("apiservice")
    .WithReference(blobs);

builder.AddProject<Projects.AspirePreview6Restore_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
