using BackEnd_SocialE.Learning.Domain.Repositories;
using BackEnd_SocialE.Learning.Domain.Services;
using BackEnd_SocialE.Learning.Mapping;
using BackEnd_SocialE.Learning.Persistence.Repositories;
using BackEnd_SocialE.Learning.Services;
using BackEnd_SocialE.Security.Domain.Repositories;
using BackEnd_SocialE.Security.Persistence.Repositories;
using BackEnd_SocialE.Security.Services;
using BackEnd_SocialE.Shared.Persistence.Contexts;
using BackEnd_SocialE.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Security Injection Configuration
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(BackEnd_SocialE.Security.Mapping.ModelToResourceProfile),
    typeof(ResourceToModelProfile),
    typeof(BackEnd_SocialE.Security.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>()) {
    context.Database.EnsureCreated();//ERROR!!!!
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();