var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.TimeLogger_API>("timelogger-api");

builder.AddProject<Projects.TimeReports_API>("timereports-api");

builder.Build().Run();
