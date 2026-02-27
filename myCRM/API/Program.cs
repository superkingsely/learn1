using DATA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MODELS;
using SERVICE;
using SERVICE.Iservice;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

// reg db context
builder.Services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

// SignIn manager
builder.Services
    .AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

    // add services
    builder.Services.AddScoped<IAuthService,AuthService>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Welcom to CJ API");
app.MapControllers();

app.Run();
