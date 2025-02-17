var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
    .WithDataVolume()
    .WithOpenWebUI();
    //.WithGPUSupport();

var deepseek = ollama.AddModel("deepseek-r1:8b");

var apiService = builder.AddProject<Projects.BlazoreChatDeepSeek_ApiService>("apiservice");

builder.AddProject<Projects.BlazoreChatDeepSeek_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);


builder.Build().Run();
