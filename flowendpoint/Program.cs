
using Scalar.AspNetCore;
using DotNetEnv;

DotNetEnv.Env.Load();
var builder=WebApplication.CreateBuilder();

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Configuration.AddEnvironmentVariables();



var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();

app.Run();