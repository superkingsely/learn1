
using Microsoft.EntityFrameworkCore;
using playground.Repository;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// builder.Services.AddDbContext<playground.Data.AppDbContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
// });

builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();
app.Run();