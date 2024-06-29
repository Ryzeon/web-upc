using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pratica_pc2_1.API.Hr.Application.Internal.Commandservices;
using pratica_pc2_1.API.Hr.Domain.Repositories;
using pratica_pc2_1.API.Hr.Domain.Services;
using pratica_pc2_1.API.Hr.Infrastructure.Persistence.EFC.Repositories;
using pratica_pc2_1.API.Shared.Domain.Repositories;
using pratica_pc2_1.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using pratica_pc2_1.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using pratica_pc2_1.API.Shared.Interfaces.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Reservations API",
                Version = "v1",
                Description = "Reservations Platform API",
                TermsOfService = new Uri("https://reservation.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "u20221a322 Studios",
                    Email = "dev@ryzeon.me"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Reservation Bounded Context Injection Configuration
builder.Services.AddScoped<IReservationRepository, ReservationRepositoryImpl>();
builder.Services.AddScoped<IReservationCommandService, ReservationCommandServiceImpl>();

// Profiles Bounded Context Injection Configuration
// builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
// builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
// builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For exeption handler
app.UseMiddleware<ErrorHandlerMiddleware>();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
