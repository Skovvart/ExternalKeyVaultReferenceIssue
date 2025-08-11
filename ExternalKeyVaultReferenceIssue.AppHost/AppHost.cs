var builder = DistributedApplication.CreateBuilder(args);

var kv = builder
    .AddAzureKeyVault("kv")
    .AsExisting(builder.AddParameter("existing-kv"), builder.AddParameter("IAMResourceGroup"));

builder.AddAzureContainerAppEnvironment("env");

builder
    .AddProject<Projects.ConsoleApp1>("console")
    .WithEnvironment("Secret", kv.GetSecret("Existing--Secret"));

//builder
//    .AddAzureFunctionsProject<Projects.FunctionApp1>("func")
//    .WaitFor(kv)
//    .WithEnvironment("Secret", kv.GetSecret("Existing--Secret"));

builder.Build().Run();
