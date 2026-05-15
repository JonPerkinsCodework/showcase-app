using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Utopia_Api>("api");
var blazor = builder.AddProject<Utopia_Blazor>("blazor");
var worker = builder.AddProject<Utopia_Worker>("worker");

builder.Build().Run();
