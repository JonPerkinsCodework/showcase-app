using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql")
                 .WithDataVolume()
                 .WithEndpoint("tcp", e => e.Port = 1433)
                 .AddDatabase("UtopiaDb");

var api = builder.AddProject<Projects.Utopia_Api>("api")
                 .WithReference(sql);

var blazor = builder.AddProject<Utopia_Blazor>("blazor");
var worker = builder.AddProject<Utopia_Worker>("worker");

builder.Build().Run();
