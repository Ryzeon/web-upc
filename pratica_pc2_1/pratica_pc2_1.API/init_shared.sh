#!/bin/bash

# Verificar si se proporcionaron suficientes argumentos
if [ "$#" -ne 2 ]; then
    echo "Uso: $0 <path> <namespace>"
    exit 1
fi

# Obtener los argumentos del path y namespace
BASE_PATH=$1
NAME_SPACE=$2

# Reemplazar puntos con slashes para formar la estructura de directorios

# Crear la estructura de carpetas si no existen para las interfaces de dominio
mkdir -p "$BASE_PATH"/Shared/Domain/Repositories
mkdir -p "$BASE_PATH"/Shared/Domain/Model/Exceptions

# Crear el archivo GenericException.cs en el namespace de dominio
#cat > "$BASE_PATH"/Shared/Domain/Model/Exceptions/GenericException.cs <<EOF
#namespace ${NAME_SPACE}.Shared.Domain.Model.Exceptions
#{
#public class GenericException : Exception
#{
#    public GenericException(string message) : base(message)
#    {
#    }
#    
#    public GenericException(string message, Exception innerException) : base(message, innerException)
#    {
#    }
#}
#}
#EOF

# Crear el archivo IUnitOfWork.cs en el namespace de dominio
cat > "$BASE_PATH"/Shared/Domain/Repositories/IUnitOfWork.cs <<EOF
namespace ${NAME_SPACE}.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
EOF

# Crear el archivo IBaseRepository.cs en el namespace de dominio
cat > "$BASE_PATH"/Shared/Domain/Repositories/IBaseRepository.cs <<EOF
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ${NAME_SPACE}.Shared.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindByIdAsync(int id);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
EOF

# Crear la estructura de carpetas si no existen para las interfaces de infraestructura
mkdir -p "$BASE_PATH"/Shared/Infrastructure/Interfaces/ASP/Configuration/Extensions
mkdir -p "$BASE_PATH"/Shared/Infrastructure/Interfaces/ASP/Configuration

# Crear el archivo KebabCaseRouteNamingConvention.cs en el namespace de infraestructura
cat > "$BASE_PATH"/Shared/Infrastructure/Interfaces/ASP/Configuration/KebabCaseRouteNamingConvention.cs <<EOF
using ${NAME_SPACE}.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ${NAME_SPACE}.Shared.Infrastructure.Interfaces.ASP.Configuration
{
    public class KebabCaseRouteNamingConvention : IControllerModelConvention
    {
        private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
        {
            return selector.AttributeRouteModel != null 
                ? new AttributeRouteModel { Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase()) } 
                : null;
        }

        public void Apply(ControllerModel controller)
        {
            foreach (var selector in controller.Selectors) 
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

            foreach (var selector in controller.Actions.SelectMany(a => a.Selectors)) 
                selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
        }
    }
}
EOF

# Crear el archivo ModelStateExtensions.cs en el namespace de extensiones de configuración
cat > "$BASE_PATH"/Shared/Infrastructure/Interfaces/ASP/Configuration/Extensions/ModelStateExtensions.cs <<EOF
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace ${NAME_SPACE}.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary
                .SelectMany(m => m.Value!.Errors)
                .Select(m => m.ErrorMessage)
                .ToList();
        }
    }
}
EOF

# Crear el archivo StringExtensions.cs en el namespace de extensiones de configuración
cat > "$BASE_PATH"/Shared/Infrastructure/Interfaces/ASP/Configuration/Extensions/StringExtensions.cs <<EOF
using System.Text.RegularExpressions;

namespace ${NAME_SPACE}.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions
{
    public static partial class StringExtensions
    {
        public static string ToKebabCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return KebabCaseRegex().Replace(text, "-\$1") 
                .Trim()
                .ToLower();
        }

        private static Regex KebabCaseRegex()
        {
            return new Regex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled);
        }
    }
}
EOF

# Crear la estructura de carpetas si no existen para las implementaciones de infraestructura
mkdir -p "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Repositories
mkdir -p "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Configuration
mkdir -p "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Configuration/Extensions

# Crear el archivo AppDbContext.cs en el namespace de configuración EFC
cat > "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Configuration/AppDbContext.cs <<EOF
using ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // Place here your entities configuration

            // Place here your entities configuration

            // modelBuilder.Entity<Booking>().ToTable("bookings");
            // modelBuilder.Entity<Booking>().HasKey(b => b.Id);
            // modelBuilder.Entity<Booking>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            // modelBuilder.Entity<Booking>().Property(b => b.UserName).IsRequired();
            // modelBuilder.Entity<Booking>().OwnsOne(b => b.RouteIdValue, r =>
            // {
            //     r.WithOwner().HasForeignKey("Id");
            //     r.Property(rid => rid.IdRoute).HasColumnName("RouteId");
            // });
            // modelBuilder.Entity<Booking>().Property(b => b.Comments);
            // modelBuilder.Entity<Booking>().Property(b => b.CreatedAt).IsRequired();
            // modelBuilder.Entity<Booking>().Property(b => b.Days).IsRequired();
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
EOF

# Crear el archivo ModelBuilderExtensions.cs en el namespace de extensiones de configuración EFC
cat > "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Configuration/Extensions/ModelBuilderExtensions.cs <<EOF
using Microsoft.EntityFrameworkCore;

namespace ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void UseSnakeCaseWithPluralizedTableNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var tableName = entity.GetTableName();
                if (!string.IsNullOrEmpty(tableName)) entity.SetTableName(tableName.ToPlural().ToSnakeCase());

                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());

                foreach (var key in entity.GetKeys())
                {
                    var keyName = key.GetName();
                    if (!string.IsNullOrEmpty(keyName)) key.SetName(keyName.ToSnakeCase());
                }

                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    var foreignKeyConstraintName = foreignKey.GetConstraintName();
                    if (!string.IsNullOrEmpty(foreignKeyConstraintName))
                        foreignKey.SetConstraintName(foreignKeyConstraintName.ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    var indexDatabaseName = index.GetDatabaseName();
                    if (!string.IsNullOrEmpty(indexDatabaseName)) index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
                }
            }
        }
    }
}
EOF

# Crear el archivo StringExtensions.cs en el namespace de extensiones de configuración EFC
cat > "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Configuration/Extensions/StringExtensions.cs <<EOF
using Humanizer;

using Microsoft.EntityFrameworkCore;

namespace ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
public static class StringExtensions
{
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
    }

    public static string ToPlural(this string text)
    {
        return text.Pluralize(inputIsKnownToBeSingular:false);
    }

}
EOF

# Crear el archivo UnitOfWork.cs en el namespace de configuration de repositories EFC
cat > "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Repositories/UnitOfWork.cs <<EOF
using ${NAME_SPACE}.Shared.Domain.Repositories;
using ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{

    public async Task CompleteAsync() => await context.SaveChangesAsync();
    
}
EOF

# Crear el archivo BaseRepository.cs en el namespace de configuration de repositories EFC
cat > "$BASE_PATH"/Shared/Infrastructure/Persistence/EFC/Repositories/BaseRepository.cs <<EOF
using ${NAME_SPACE}.Shared.Domain.Repositories;
using ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}
EOF

mkdir -p "$BASE_PATH"/Shared/Infrastructure/Interfaces/Middleware

cat > "$BASE_PATH"/Shared/Infrastructure/Interfaces/Middleware/ErrorHandlerMiddleware.cs <<EOF
using System.Data;
using System.Net;
using ${NAME_SPACE}.Shared.Domain.Model.Exceptions;

namespace ${NAME_SPACE}.Shared.Interfaces.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }


    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

   private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.BadRequest;
        var result = ex.Message;
        
        // Add handlers for custom exeptions.

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        var jsonResult = System.Text.Json.JsonSerializer.Serialize(new { message = result });
        await context.Response.WriteAsync(jsonResult);
    }
}
EOF

rm -r "$BASE_PATH"/Program.cs
cat > "$BASE_PATH"/Program.cs << EOF
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ${NAME_SPACE}.Shared.Domain.Repositories;
using ${NAME_SPACE}.Shared.Infrastructure.Interfaces.ASP.Configuration;
using ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Configuration;
using ${NAME_SPACE}.Shared.Infrastructure.Persistence.EFC.Repositories;
using ${NAME_SPACE}.Shared.Interfaces.Middleware;

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
                Title = "ACME.LearningCenterPlatform.API",
                Version = "v1",
                Description = "ACME Learning Center Platform API",
                TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
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
EOF

cat > "$BASE_PATH"/appsettings.json << EOF
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost,3306;user=root;password=password;database=YOURDBHERE"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
EOF

echo "Estructura y archivos creados correctamente en $BASE_PATH"

cat > "$BASE_PATH"/"${NAME_SPACE}".csproj << EOF
<Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net8.0</TargetFramework>
        <Nullable>enable</Nullable>
        <ImplicitUsings>enable</ImplicitUsings>
    </PropertyGroup>

    <ItemGroup>
        <!-- Dependency Injection related packages -->
        <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
        <!-- Entity Framework Core related packages -->
        <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.4" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.4" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Relational.Design" Version="1.1.6" />
        <!-- MySQL Database related packages -->
        <PackageReference Include="MySql.EntityFrameworkCore" Version="8.0.2" />
        <!-- Audit trails related packages -->
        <PackageReference Include="EntityFrameworkCore.CreatedUpdatedDate" Version="8.0.0" />
        <!-- Naming conventions related packages -->
        <PackageReference Include="Humanizer" Version="2.14.1" />
        <!-- OpenAPI Documentation related packages -->
        <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0"/>
        <PackageReference Include="Swashbuckle.AspNetCore.Annotations" Version="6.5.0"/>
    </ItemGroup>

</Project>
EOF
