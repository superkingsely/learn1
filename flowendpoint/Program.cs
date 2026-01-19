
using Scalar.AspNetCore;

var builder=WebApplication.CreateBuilder();

builder.Services.AddOpenApi();
builder.Services.AddControllers();



var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.MapOpenApi();
app.MapScalarApiReference();

app.Run();