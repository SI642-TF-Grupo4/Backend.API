using BackEnd.API.Credit.Domain.Repositories;
using BackEnd.API.Credit.Domain.Services;
using BackEnd.API.Credit.Persistence.Repositories;
using BackEnd.API.Credit.Services;
using BackEnd.API.Security.Authorization.Handlers.Implementations;
using BackEnd.API.Security.Authorization.Handlers.Interfaces;
using BackEnd.API.Security.Authorization.Settings;
using BackEnd.API.Security.Domain.Repositories;
using BackEnd.API.Security.Domain.Services;
using BackEnd.API.Security.Mapping;
using BackEnd.API.Security.Persistence.Repositories;
using BackEnd.API.Security.Services;
using BackEnd.API.Shared.Domain.Repositories;
using BackEnd.API.Shared.Persistence.Contexts;
using BackEnd.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API",
        Description = "Restful API",
    });
    options.EnableAnnotations();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Lower Case URLs Configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Authentication Bounded Context Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IPasswordHashingService, PasswordHashingService>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile)
);

builder.Services.AddAutoMapper(
    typeof(BackEnd.API.Credit.Mapping.ModelToResourceProfile),
    typeof(BackEnd.API.Credit.Mapping.ResourceToModelProfile)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors(x => 
    x.SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();