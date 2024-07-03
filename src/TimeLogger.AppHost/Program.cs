var builder = DistributedApplication.CreateBuilder(args);

var sql = builder.AddSqlServer("sql");
var timeloggerDb = sql.AddDatabase("TimeLoggerDbConnection");

//var serviceBus = builder.ExecutionContext.IsPublishMode
//    ? builder.AddAzureServiceBus("ServiceBus")
//    : builder.AddConnectionString("ServiceBus");

builder.AddProject<Projects.TimeLogger_API>("timelogger-api")
    .WithReference(timeloggerDb);
//.WithReference(serviceBus);

builder.AddProject<Projects.TimeReports_API>("timereports-api");
    //.WithReference(serviceBus);

builder.Build().Run();
