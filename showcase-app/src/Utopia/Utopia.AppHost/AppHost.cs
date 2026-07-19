using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// Create the SQL Server resource
var sqlServer = builder.AddSqlServer("sql")
                       .WithDataVolume()
                       .WithEndpoint("tcp", e => e.Port = 1433);

// Reference the *database* resource in the API
var api = builder.AddProject<Projects.Utopia_Api>("api")
                 .WithReference(sqlServer); var blazor = builder.AddProject<Utopia_Blazor>("blazor");
var worker = builder.AddProject<Utopia_Worker>("worker");

builder.Build().Run();
