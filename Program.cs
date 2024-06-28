using Dependency_Injection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

builder.Services.AddScoped<IMyDependency, MyDependency>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
